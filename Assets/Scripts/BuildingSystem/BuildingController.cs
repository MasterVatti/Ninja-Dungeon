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

        public List<Resource> RequiredResource { get; set; } = new List<Resource>();
        public BuildingSettings BuildingSettings { get; private set; }

        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;

        private void Start()
        {
            //копируем значения списка необходимых ресурсов, чтобы не менять настройки
            // но только в том случае, если из сохранения нам суюда прилетел пустой список
            if (RequiredResource.Count == 0)
            {
                RequiredResource = new List<Resource>(BuildingSettings.UpgradeList[0].UpgradeCost);
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

        public void Initialize(BuildingSettings buildingSettings)
        {
            BuildingSettings = buildingSettings;
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
            for(var i = 0; i < RequiredResource.Count; i++)
            {
                if (RequiredResource[i].Amount > 0 &&
                    IsPaymentTime(RequiredResource[i]) &&
                    MainManager.ResourceManager.HasEnough(RequiredResource[i].Type, PAY_PER_TICK))
                {
                    MainManager.ResourceManager.Pay(RequiredResource[i].Type, PAY_PER_TICK);
                    
                    var resource = RequiredResource[i];
                    resource.Amount -= PAY_PER_TICK;
                    RequiredResource[i] = resource;
                    
                    MainManager.AnimationManager.ShowFlyingResource
                        (RequiredResource[i].Type, MainManager.PlayerMovementController.transform.position, transform.position);
                }
            }

            if (IsConstructionFinished())
            {
                FinishConstruction();
                MainManager.BuildingManager.ActivePlaceHolders.Remove(gameObject);
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

        private void FinishConstruction()
        {
            BuildingUtils.CreateNewConstruction(BuildingSettings, true);
            foreach (var placeHolder in BuildingSettings.ConnectedBuildings)
            {
                BuildingUtils.CreateNewConstruction(placeHolder, false);
            }
        }
    }
}
