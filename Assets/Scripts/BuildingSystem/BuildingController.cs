using System;
using System.Collections.Generic;
using System.Linq;
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
        public event Action OnBuildFinished;
        private const int PAY_PER_TICK = 1;

        public BuildingSettings BuildingSettings { get; set; }
        private List<Resource> _requiredResource = new List<Resource>();
        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;

        private void Start()
        {
            //создаём копию списка необходимых ресурсов, чтобы не менять настройки
            _requiredResource = BuildingSettings.RequiredResources.ToList();
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
                var go = Instantiate(placeHolderPrefab, placeHolderPosition, Quaternion.identity);
                go.GetComponent<BuildingController>().BuildingSettings = buildingSettings;
            }
            else
            {
                Instantiate(buildingSettings.BuildingPrefab, placeHolderPosition, Quaternion.identity);
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
                    ResourceManager.Instance.HasEnough(requiredResource.Type, PAY_PER_TICK))
                {
                    ResourceManager.Instance.Pay(requiredResource.Type, PAY_PER_TICK);
                    requiredResource.Amount -= PAY_PER_TICK;
                }
            }

            if (IsConstructionFinished())
            {
                OnBuildFinished?.Invoke();
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
