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
        public event Action OnBuildFinished;
        private const int PAY_PER_TICK = 1;

        public BuildingSettings Building
        {
            get => _building;
            set => _building = value;
        }
        
        [SerializeField]
        private BuildingSettings _building;
        private List<Resource> _requiredResource = new List<Resource>();
        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;

        private void Start()
        {
            foreach (var resource in _building.RequiredResources)
            {
                var item = new Resource() {Amount = resource.Amount, Type = resource.Type};
                _requiredResource.Add(item);
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

        private void SetRequiredCooldown()
        {
            _requiredCooldown = new Dictionary<ResourceType, float>();
            _currentCooldown = new Dictionary<ResourceType, float>();
            foreach (var requiredResource in _requiredResource)
            {
                _requiredCooldown.Add(requiredResource.Type, 
                    _building.TimeToBuild / requiredResource.Amount);
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
                    ResourceManager.Instance.HasEnough(requiredResource.Type, PayPerTick))
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
