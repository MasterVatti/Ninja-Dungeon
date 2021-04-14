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
        private void Start()
        {
            var constructedBuildings = MainManager.BuildingManager.ActiveBuildings;
            
            foreach (var building in constructedBuildings)
            {
                var buildingID = building.GetComponent<IBuilding>().BuildingSettingsID;
                
                var settings = MainManager.BuildingManager.GetBuildingSettings(buildingID);
                
                AddUIToBuilding(building,settings);
            }

            MainManager.BuildingManager.OnBuildFinished += AddUIToBuilding;
        }

        private void AddUIToBuilding(GameObject building, BuildingSettings setting)
        {
            if (building.TryGetComponent(out IBuildingUIPositionHolder buildingUI))
            {
                CreateBuildingInfoView(building, setting.BuildingInfoView, buildingUI.PositionUI, setting.BuildingName);
            }
        }   
        
        private void CreateBuildingInfoView(GameObject building, BuildingInfoView buildingInfoView,
         Transform uiAttachPoint, string nameBuilding)
        {
            var buildingView = Instantiate(buildingInfoView, transform);
            
            buildingView.Initialize(building, uiAttachPoint, nameBuilding);
        }
        
        private void OnDestroy()
        {
            MainManager.BuildingManager.OnBuildFinished -= AddUIToBuilding;
        }
    }
}
