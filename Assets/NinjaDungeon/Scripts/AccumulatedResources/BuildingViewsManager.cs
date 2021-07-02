using BuildingSystem;
using NinjaDungeon.Scripts.Managers;
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
            var constructedBuildings = UpperWorldManager.BuildingManager.ActiveBuildings;
            
            foreach (var building in constructedBuildings)
            {
                var buildingID = building.GetComponent<IBuilding>().BuildingSettingsID;
                var settings = UpperWorldManager.BuildingManager.GetBuildingSettings(buildingID);
                
                AddBuildingView(building,settings);
            }

            UpperWorldManager.BuildingManager.OnBuildFinished += AddBuildingView;
        }

        private void AddBuildingView(GameObject building, BuildingSettings setting)
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
            UpperWorldManager.BuildingManager.OnBuildFinished -= AddBuildingView;
        }
    }
}
