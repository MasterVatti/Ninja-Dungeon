using System.Collections.Generic;
using Assets.Scripts;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Класс вычисляет скорость оплаты строительства
    /// и контролирует процесс строительства
    /// </summary>
    public class BuildingController : MonoBehaviour
    {
        private const int PAY_PER_TICK = 1;

        public BuildingSettings BuildingSettings { get; private set; }

        public List<Resource> RequiredResource { get; set; } = new List<Resource>();
        
        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;

        private void Start()
        {
            //копируем значения списка необходимых ресурсов, чтобы не менять настройки
            // но только в том случае, если из сохранения нам суюда прилетел пустой список
            if (RequiredResource.Count == 0)
            {
                foreach (var requiredResource in BuildingSettings.RequiredResources)
                {
                    RequiredResource.Add(new Resource
                    {
                        Type = requiredResource.Type,
                        Amount = requiredResource.Amount
                    });
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                SetRequiredCooldown();
                Build();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!IsConstructionFinished() && other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                Build();
            }
        }

        public static GameObject CreateNewBuilding(BuildingSettings buildingSettings, bool isBuilding)
        {
            var placeHolderPosition = buildingSettings.PlaceHolderPosition;
            if (isBuilding)
            {
                var buildingPrefab = buildingSettings.BuildingPrefab;
                var building = Instantiate(buildingPrefab, placeHolderPosition, buildingPrefab.transform.rotation);
                MainManager.BuildingManager.ActiveBuildings.Add(building);
                
                return building;
            }
            var placeHolderPrefab = buildingSettings.PlaceHolderPrefab;
            var placeHolderRotation = placeHolderPrefab.transform.rotation;
                
            var placeHolder = Instantiate(placeHolderPrefab, placeHolderPosition, placeHolderRotation);
            placeHolder.GetComponent<BuildingController>().BuildingSettings = buildingSettings;
            MainManager.BuildingManager.ActivePlaceHolders.Add(placeHolder);
                
            return placeHolder;
        }
        
        private void SetRequiredCooldown()
        {
            _requiredCooldown = new Dictionary<ResourceType, float>();
            _currentCooldown = new Dictionary<ResourceType, float>();
            foreach (var requiredResource in RequiredResource)
            {
                _requiredCooldown.Add(requiredResource.Type, 
                    BuildingSettings.TimeToBuild / requiredResource.Amount);
                _currentCooldown.Add(requiredResource.Type,
                    float.MinValue);
            }
        }

        private void Build()
        {
            foreach (var requiredResource in RequiredResource)
            {
                if (requiredResource.Amount > 0 && 
                    IsPaymentTime(requiredResource) && 
                    MainManager.ResourceManager.HasEnough(requiredResource.Type, PAY_PER_TICK))
                {
                    MainManager.ResourceManager.Pay(requiredResource.Type, PAY_PER_TICK);
                    requiredResource.Amount = PAY_PER_TICK;
                }
            }

            if (IsConstructionFinished())
            {
                new BuildFinisher(BuildingSettings, BuildingSettings.ConnectedPlaceHolders).FinishBuilding();
                Destroy(gameObject);
            }
        }

        private bool IsConstructionFinished()
        {
            return RequiredResource.TrueForAll(IsResourceExpired);
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

        private void OnDestroy()
        {
            MainManager.BuildingManager.ActivePlaceHolders.Remove(gameObject);
        }
    }
}
