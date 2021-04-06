using System.Collections.Generic;
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
        private MinerInfoView _minerViewPrefab;
    

        void Start()
        {
            var constructedBuildings = MainManager.BuildingManager.ActiveBuildings;
            foreach (var building in constructedBuildings)
            {
                var settings = MainManager.BuildingManager.GetBuildingSettings(building.GetComponent<IBuilding>().BuildingSettingsID);
                
                AddUIToBuilding(building,settings);
            }

            MainManager.BuildingManager.OnBuildFinished += AddUIToBuilding;
        }

        private void AddUIToBuilding(GameObject buildingView, BuildingSettings buildingSettings)
        {
            
            //CreateAccumulatedResourceUI(buildingView,miner.PositionUI);
        }
    
        private void CreateAccumulatedResourceUI(ResourceMiner resourceMiner,Transform UIposition)
        {
            var accumulatedResource = Instantiate(_minerViewPrefab,transform);
        
            accumulatedResource.Initialize(resourceMiner,UIposition.position,GetResourceSprite(resourceMiner),"123");
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
