using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;

namespace AccumulatedResources
{
    /// <summary>
    /// Класс распределяет зданиям с ResourceMiner UI для показа ресурсов текущие/максимум
    /// </summary>
    public class BuildingViewsManager : MonoBehaviour
    {
        [SerializeField]
        private List<ResourceImage> _resourceImages = new List<ResourceImage>();
        
        void Start()
        {
            var constructedBuildings = MainManager.BuildingManager.ActiveBuildings;
            foreach (var building in constructedBuildings)
            {
                var settings = MainManager.BuildingManager.GetBuildingSettings
                    (building.GetComponent<IBuilding>().BuildingSettingsID);
                
                AddUIToBuilding(building,settings);
            }

            MainManager.BuildingManager.OnBuildFinished += AddUIToBuilding;
        }

        private void AddUIToBuilding(GameObject building, BuildingSettings setting)
        {
            if (building.TryGetComponent(out ResourceMiner miner))
            {
                CreateMinerView(miner,setting.BuildingInfoView,miner.PositionUI,setting.BuildingName);
            } 
            
            else if (building.TryGetComponent(out IBuildingUIPositionHolder buildingUI))
            {
                CreateBuildingInfoView(setting.BuildingInfoView,buildingUI.PositionUI,setting.BuildingName);
            }
        }   
    
        private void CreateMinerView
            (ResourceMiner resourceMiner, BuildingInfoView buildingInfoView, Transform positionUI,string nameBuilding)
        {
            var minerView = 
                Instantiate(buildingInfoView.GetComponentInChildren<MinerInfoView>(),transform);
        
            minerView.Initialize
                (resourceMiner,positionUI.position,GetResourceSprite(resourceMiner),nameBuilding);
        }

        private void CreateBuildingInfoView(BuildingInfoView buildingInfoView, Transform positionUI,string nameBuilding)
        {
            var buildingView = Instantiate(buildingInfoView, transform);
            
            buildingView.Initialize(positionUI.position,nameBuilding);
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
