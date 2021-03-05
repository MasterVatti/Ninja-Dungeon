using System;
using PlayerScripts;
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
        [SerializeField]
        private int _constructionSpeedMultiplier;
        [SerializeField]
        private float _buildCooldown;
        private float _buildTime;
        private int[] _playerResources;
        private int _constructionSpeed;

        private void Start ()
        {
            _playerResources = PlayerResourcesManager.CurrentResources;
            OnBuildFinished += delegate
            {
                BuildFinisher.CreateBuilding(_building.Prefab);
                BuildFinisher.CreatePlaceHolders(_building.ConnectedPlaceHolders);
            };
        }

        private void OnTriggerEnter (Collider other)
        {
            _constructionSpeed = SetConstructionSpeed();
            _buildTime = Time.time;
            Build(_constructionSpeed);
        }

        private void OnTriggerStay (Collider other)
        {
            if(!IsConstructionFinished())
            {
                Build(_constructionSpeed);
            }
        }

        private int SetConstructionSpeed ()
        {
            var constructionSpeed = 1;
            var requiredResources = _building.RequiredResources;
            for(var i = 0; i < _playerResources.Length; i++)
            {
                if(_playerResources[i] < 1 || requiredResources[i] == 0)
                {
                    continue;
                }

                var difference = _playerResources[i] / requiredResources[i];
                if(constructionSpeed > difference)
                {
                    constructionSpeed = difference;
                }
            }

            return constructionSpeed;
        }

        private void Build (int speed)
        {
            var payPerSecond = speed * _constructionSpeedMultiplier;
            var requiredResources = _building.RequiredResources;
            if(IsCooldownExpired())
            {
                for(int i = 0; i < _playerResources.Length; i++)
                {
                    if(requiredResources[i] <= 0)
                    {
                        continue;
                    }

                    if(_playerResources[i] > payPerSecond)
                    {
                        _playerResources[i] -= payPerSecond;
                        requiredResources[i] -= payPerSecond;
                        continue;
                    }

                    if(_playerResources[i] <= payPerSecond && _playerResources[i] > 0)
                    {
                        _playerResources[i] -= 1;
                        requiredResources[i] -= 1;
                    }
                }

                _buildTime += _buildCooldown;
            }

            PlayerResourcesManager.CurrentResources = _playerResources;
            _building.RequiredResources = requiredResources;
            if(IsConstructionFinished())
            {
                OnBuildFinished?.Invoke();
            }
        }

        private bool IsCooldownExpired ()
        {
            if(Time.time > _buildTime)
            {
                return true;
            }

            return false;
        }

        private bool IsConstructionFinished ()
        {
            if(_building.RequiredResources[0] <= 0 && _building.RequiredResources[1] <= 0)
            {
                Destroy(gameObject);
                return true;
            }

            return false;
        }
    }
}
