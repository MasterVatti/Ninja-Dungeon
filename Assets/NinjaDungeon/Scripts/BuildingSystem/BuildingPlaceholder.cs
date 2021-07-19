using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using NinjaDungeon.Scripts.Managers;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Класс вычисляет скорость оплаты строительства и контролирует процесс строительства
    /// </summary>
    public class BuildingPlaceholder : MonoBehaviour, IBuildingUIPositionHolder
    {
        private const int PAY_PER_TICK = 1;

        public event Action OnPayForBuilding;

        public Transform PositionUI => _uiPosition;

        public List<Resource> RequiredResource { get; private set; }
        public BuildingSettings BuildingSettings { get; private set; }

        [SerializeField]
        private Transform _uiPosition;

        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;

        public void Initialize(BuildingSettings buildingSettings, List<Resource> requiredResources)
        {
            BuildingSettings = buildingSettings;
            RequiredResource = requiredResources ?? BuildingSettings.UpgradesInfo[0].UpgradeCost.ToList();
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

        private void SetRequiredCooldown()
        {
            _requiredCooldown = new Dictionary<ResourceType, float>();
            _currentCooldown = new Dictionary<ResourceType, float>();
            foreach (var requiredResource in RequiredResource)
            {
                _requiredCooldown.Add(requiredResource.Type,
                    BuildingSettings.TimeToBuild / requiredResource.Amount);
                _currentCooldown.Add(requiredResource.Type, float.MinValue);
            }
        }

        private void Build()
        {
            for (var i = 0; i < RequiredResource.Count; i++)
            {
                if (RequiredResource[i].Amount > 0 &&
                    IsPaymentTime(RequiredResource[i]) &&
                    MainManager.ResourceManager.HasEnough(RequiredResource[i].Type, PAY_PER_TICK))
                {
                    MainManager.ResourceManager.Pay(RequiredResource[i].Type, PAY_PER_TICK);

                    var resource = RequiredResource[i];
                    resource.Amount -= PAY_PER_TICK;
                    RequiredResource[i] = resource;

                    var playerPosition = MainManager.Player.transform.position;
                    UpperWorldManager.AnimationManager.ShowFlyingResource(RequiredResource[i].Type, playerPosition, transform.position);

                    OnPayForBuilding?.Invoke();
                }
            }

            if (IsConstructionFinished())
            {
                FinishConstruction();
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
            BuildingUtils.CreateNewBuilding(gameObject, BuildingSettings);
            
            foreach (var placeHolder in BuildingSettings.ConnectedBuildings)
            {
                BuildingUtils.CreatePlaceHolder(placeHolder, null);
            }
        }
    }
}