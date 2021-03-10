using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;
using ResourceManager = Managers.ResourceManager;

namespace BuildingSystem
{
    /// <summary>
    /// Класс вычисляет скорость строительства
    /// и контролирует процесс строительства
    /// </summary>
    public class BuildingController : MonoBehaviour
    {
        public event Action OnBuildFinished;
        [SerializeField]
        private BuildingSettings _building;
        private Dictionary<ResourceType, float> _requiredCooldown;
        private Dictionary<ResourceType, float> _currentCooldown;


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
            foreach (var requiredResource in _building.RequiredResources)
            {
                _requiredCooldown.Add(requiredResource.Type, 
                    _building.TimeToBuild / requiredResource.Amount);
                _currentCooldown.Add(requiredResource.Type, 
                    _building.TimeToBuild / requiredResource.Amount);
            }
        }

        private void Build()
        {
            foreach (var requiredResource in _building.RequiredResources)
            {
                if (requiredResource.Amount > 0 && 
                    IsPaymentTime(requiredResource) && 
                    ResourceManager.Instance.HasEnough(requiredResource.Type, 1))
                {
                    ResourceManager.Instance.Pay(requiredResource.Type, 1);
                    requiredResource.Amount--;
                }
            }

            if (IsConstructionFinished())
            {
                OnBuildFinished?.Invoke();
            }
        }

        private bool IsConstructionFinished()
        {
            return _building.RequiredResources.TrueForAll(IsResourceExpired);

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
