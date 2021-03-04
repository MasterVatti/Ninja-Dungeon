using System;
using PlayerScripts;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingController : MonoBehaviour
    {
        public event Action onBuildFinished;
        [SerializeField]
        private BuildingSettings _building;
        [SerializeField]
        private int _constructionSpeedMultiplier;
        private int[] _playerResources;
        private int _constructionSpeed;

        private void Start ()
        {
            _playerResources = PlayerResourcesManager.CurrentResources;
        }

        private void OnTriggerEnter (Collider other)
        {
            SetConstructionSpeed();
            Build(_constructionSpeed);
        }

        private void OnTriggerStay (Collider other)
        {
            Build(_constructionSpeed);
        }

        private void SetConstructionSpeed ()
        {
            var requiredResources = _building.RequiredResources;
            for(var i = 0; i < _playerResources.Length; i++)
            {
                if(_playerResources[i] < 1)
                {
                    continue;
                }

                var currentConstructionSpeed = _playerResources[i] / requiredResources[i];
                currentConstructionSpeed = currentConstructionSpeed < 1 ? 1 : currentConstructionSpeed;
                if(currentConstructionSpeed < _constructionSpeed)
                {
                    _constructionSpeed = currentConstructionSpeed;
                    Debug.Log(currentConstructionSpeed);
                }
            }
        }

        private void Build (int speed)
        {
            var paidPerSecond = speed * _constructionSpeedMultiplier;
            var requiredResources = _building.RequiredResources;
            for(int i = 0; i < _playerResources.Length; i++)
            {
                if(_playerResources[i] > paidPerSecond)
                {
                    _playerResources[i] -= paidPerSecond;
                    requiredResources[i] -= paidPerSecond;
                    continue;
                }
                if(_playerResources[i] < paidPerSecond && _playerResources[i] > 1)
                {
                    _playerResources[i] -= 1;
                    requiredResources[i] -= 1;
                }
            }
            Debug.Log(speed);
            PlayerResourcesManager.CurrentResources = _playerResources;
            _building.RequiredResources = requiredResources;
            CheckingEndOfTheConstruction();
        }

        private void CheckingEndOfTheConstruction ()
        {
            if(_building.RequiredResources[0] <= 0 && _building.RequiredResources[1] <= 0)
            {
                onBuildFinished?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
