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
            if (building.TryGetComponent(out IBuildingUIPositionHolder buildingUI))
            {
                CreateBuildingInfoView(building, setting.BuildingInfoView, buildingUI.PositionUI, setting.BuildingName);
            }
        }   
        
        private void CreateBuildingInfoView
            (GameObject building, BuildingInfoView buildingInfoView, Transform positionUI, string nameBuilding)
        {
            var buildingView = Instantiate(buildingInfoView, transform);
            
            buildingView.Initialize(building, positionUI, nameBuilding);
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
