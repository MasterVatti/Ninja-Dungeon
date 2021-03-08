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
        private PlayerResourcesManager _playerResources;
        private float _startTime;

        private void Start ()
        {
            _playerResources = PlayerResourcesManager.Instance;
        }


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
                    foreach (var playerResource in _playerResources.CurrentResources)
                    {
                        if(requiredResource.Type != playerResource.Type || !(requiredResource.Amount > 0))
                        {
                            continue;
                        }

                        var deductAmount = GetDeductAmount(requiredResource.Type);
                        if(deductAmount > requiredResource.Amount || deductAmount > playerResource.Amount)
                        {  
                            if(playerResource.Amount > requiredResource.Amount)
                            {
                                playerResource.Amount -= requiredResource.Amount;
                                requiredResource.Amount = 0;
                            }
                            else
                            {
                                requiredResource.Amount -= playerResource.Amount;
                                playerResource.Amount = 0;
                            }
                            break;
                        }
                        playerResource.Amount -= deductAmount;
                        requiredResource.Amount -= deductAmount;
                        break;
                    }
                }

                _startTime += 1;
            }

            if(IsConstructionFinished())
            {
                Destroy(gameObject);
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
                    Debug.Log(deduct.Type + " " + deduct.Amount);
                    return deduct.Amount;
                }
            }

            return 0;
        }
    }
}
