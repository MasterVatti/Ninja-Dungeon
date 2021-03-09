using System;
using System.Collections.Generic;
using PlayerScripts;
using ResourceSystem;
using UnityEngine;

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
        private List<Resource> _resourcesDeducts = new List<Resource>();
        private float _startTime;


        private void OnTriggerEnter (Collider other)
        {
            SetResourcesDeducts();
            _startTime = Time.time;
            Build();
        }

        private void OnTriggerStay (Collider other)
        {
            if(!IsConstructionFinished())
            {
                Build();
            }
        }
        
        private void SetResourcesDeducts ()
        {
            _resourcesDeducts = new List<Resource>();
            foreach (var requiredResources in _building.RequiredResources)
            {
                _resourcesDeducts.Add(new Resource() {Type = requiredResources.Type, Amount = requiredResources.Amount / _building.TimeToBuild});
            }
        }

        private void Build ()
        {
            if(IsCooldownExpired())
            {
                foreach (var requiredResource in _building.RequiredResources)
                {
                    if(requiredResource.Amount < 1)
                    {
                        requiredResource.Amount = 0;
                        continue;
                    }
                    var playerResource = Resource.GetResourceByType(PlayerResourcesManager.Instance.CurrentResources, requiredResource.Type);
                    var deductAmount = Math.Min(GetDeductAmount(requiredResource.Type), Mathf.Min(requiredResource.Amount, playerResource.Amount));
                    playerResource.Amount -= deductAmount;
                    requiredResource.Amount -= deductAmount;
                }

                _startTime += 1;
            }

            if(IsConstructionFinished())
            {
                OnBuildFinished?.Invoke();
            }
        }


        private bool IsCooldownExpired ()
        {
            return Time.time > _startTime;

        }

        private bool IsConstructionFinished ()
        {
            return _building.RequiredResources.TrueForAll(IsResourceExpired);

        }

        private bool IsResourceExpired (Resource resource)
        {
            return resource.Amount <= 0;
        }

        private float GetDeductAmount (ResourceType type)
        {
            foreach (var deduct in _resourcesDeducts)
            {
                if(deduct.Type == type)
                {
                    return deduct.Amount;
                }
            }

            return 0;
        }
    }
}
