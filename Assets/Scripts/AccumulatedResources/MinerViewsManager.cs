using System.Collections.Generic;
using Buildings;
using BuildingSystem;
using UnityEngine;

namespace AccumulatedResources
{
    /// <summary>
    /// Класс распределяет зданиям с ResourceMiner UI для показа ресурсов текущие/максимум
    /// </summary>
    public class MinerViewsManager : MonoBehaviour
    {
        [SerializeField]
        private List<ResourceImage> _resourceImages = new List<ResourceImage>();
        [SerializeField]
        private MinerView _minerViewPrefab;
    

        void Start()
        {
            var constructedBuildings = MainManager.BuildingManager.ActiveBuildings;
            foreach (var building in constructedBuildings)
            {
                AddUIToBuilding(building);
            }

            MainManager.BuildingManager.OnBuildFinished += AddUIToBuilding;
        }

        private void AddUIToBuilding(GameObject building)
        {
            if (building.TryGetComponent(out ResourceMiner miner))
            {
                CreateAccumulatedResourceUI(miner,miner.PositionUI);
            }
        }
    
        private void CreateAccumulatedResourceUI(ResourceMiner resourceMiner,Transform UIposition)
        {
            var accumulatedResource = Instantiate(_minerViewPrefab,transform);
        
            accumulatedResource.Initialize(resourceMiner,UIposition.position,GetResourceSprite(resourceMiner));
        }

        private Sprite GetResourceSprite(ResourceMiner resourceMiner)
        {
            foreach (var resource in _resourceImages)
            {
                if (resource.Type == resourceMiner.ExtractableResource)
                {
                    return resource.Sprite;
                }
            }

            return null;
        }

        private void OnDisable()
        {
            if (MainManager.BuildingManager != null)
            {
                MainManager.BuildingManager.OnBuildFinished -= AddUIToBuilding;
            }
        }
    }
}
