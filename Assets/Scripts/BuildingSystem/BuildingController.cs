using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;
using ResourceManager = Managers.ResourceManager;

namespace BuildingSystem
{
    /// <summary>
    /// Класс вычисляет скорость оплаты строительства
    /// и контролирует процесс строительства
    /// </summary>
    public class BuildingController : MonoBehaviour
    {
        private const int PAY_PER_TICK = 1;
        
        public event Action OnBuildFinished;
        
        private BuildingSettings BuildingSettings { get; set; }
        
        private List<Resource> _requiredResource = new List<Resource>();
        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;

        private void Start()
        {
            //копируем значения списка необходимых ресурсов, чтобы не менять настройки
            foreach (var requiredResource in BuildingSettings.RequiredResources)    
            {
                _requiredResource.Add(new Resource(){Type = requiredResource.Type, Amount = requiredResource.Amount});
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            SetRequiredCooldown();
            Build();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!IsConstructionFinished())
            {
                Build();
            }
        }

        public static void CreateNewBuilding(BuildingSettings buildingSettings, bool isPlaceHolder)
        {
            var placeHolderPosition = buildingSettings.PlaceHolderPosition;
            if (isPlaceHolder)
            {
                var placeHolderPrefab = buildingSettings.PlaceHolderPrefab;
                var placeHolderRotation = placeHolderPrefab.transform.rotation;
                var go = Instantiate(placeHolderPrefab, placeHolderPosition, placeHolderRotation);
                go.GetComponent<BuildingController>().BuildingSettings = buildingSettings;
            }
            else
            {
                var buildingPrefab = buildingSettings.BuildingPrefab;
                Instantiate(buildingPrefab, placeHolderPosition, buildingPrefab.transform.rotation);
            }
        }
        
        private void SetRequiredCooldown()
        {
            _requiredCooldown = new Dictionary<ResourceType, float>();
            _currentCooldown = new Dictionary<ResourceType, float>();
            foreach (var requiredResource in _requiredResource)
            {
                _requiredCooldown.Add(requiredResource.Type, 
                    BuildingSettings.TimeToBuild / requiredResource.Amount);
                _currentCooldown.Add(requiredResource.Type,
                    float.MinValue);
            }
        }

        private void Build()
        {
            foreach (var requiredResource in _requiredResource)
            {
                if (requiredResource.Amount > 0 && 
                    IsPaymentTime(requiredResource) && 
                    MainManager.ResourceManager.HasEnough(requiredResource.Type, PAY_PER_TICK))
                {
                    MainManager.ResourceManager.Pay(requiredResource.Type, PAY_PER_TICK);
                    requiredResource.Amount -= PAY_PER_TICK;
                }
            }

            if (IsConstructionFinished())
            {
                new BuildFinisher(BuildingSettings, BuildingSettings.ConnectedPlaceHolders).FinishBuilding();
                MainManager.BuildingManager.ConstructedBuldings.Add(BuildingSettings.PlaceHolderPrefab);
                OnBuildFinished?.Invoke();
                Destroy(gameObject);
            }
        }

        private bool IsConstructionFinished()
        {
            return _requiredResource.TrueForAll(IsResourceExpired);
        }

        private bool IsResourceExpired(Resource resource)
        {
            return resource.Amount <= 0;
        }

        private bool IsPaymentTime(Resource resource)
        {
            if (Time.time > _currentCooldown[resource.Type])
            {
                _currentCooldown[resource.Type] = Time.time + _requiredCooldown[resource.Type];
                return true;
            }

            return false;
        }
    }
}
