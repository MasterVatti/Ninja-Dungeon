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
            SetConstructionSpeed();
            _buildTime = Time.time;
            Build(_constructionSpeed);
        }

        private void OnTriggerStay (Collider other)
        {
            Build(_constructionSpeed);
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

                constructionSpeed = _playerResources[i] / requiredResources[i];
            }

            return constructionSpeed;
        }

        private void Build (int speed)
        {
            var paidPerSecond = speed * _constructionSpeedMultiplier;
            var requiredResources = _building.RequiredResources;
            if(Time.time > _buildTime)
            {
                for(int i = 0; i < _playerResources.Length; i++)
                {
                    if(requiredResources[i] <= 0)
                    {
                        continue;
                    }

                    if(_playerResources[i] > paidPerSecond)
                    {
                        _playerResources[i] -= paidPerSecond;
                        requiredResources[i] -= paidPerSecond;
                        continue;
                    }

                    if(_playerResources[i] <= paidPerSecond && _playerResources[i] > 0)
                    {
                        _playerResources[i] -= 1;
                        requiredResources[i] -= 1;
                    }
                }

                _buildTime += _buildCooldown;
            }
            PlayerResourcesManager.CurrentResources = _playerResources;
            _building.RequiredResources = requiredResources;
            CheckingEndOfTheConstruction();
        }

        private void CheckingEndOfTheConstruction ()
        {
            if(_building.RequiredResources[0] <= 0 && _building.RequiredResources[1] <= 0)
            {
                OnBuildFinished?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
