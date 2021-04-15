using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class BuildingUpgrader
    {
        private readonly IUpgrader _upgrader;

        public BuildingUpgrader(IUpgrader upgrader)
        {
            _upgrader = upgrader;
        }

        public void Upgrade<T>(Building<T> building) where T : BaseBuildingState
        {
            var settingsID = building.BuildingSettingsID;
            var settings = MainManager.BuildingManager.GetBuildingSettings(settingsID);
            var buildingLevel = building.GetComponent<IUpgradable>().CurrentBuildingLevel + 1;
            if (settings.UpgradeList.Count > buildingLevel)
            {
                var go = _upgrader.Upgrade(settings, buildingLevel);
                if (go == null)
                {
                    return;
                }
                
                var oldBuilding = building.gameObject;

                MainManager.BuildingManager.ActiveBuildings.Remove(oldBuilding);
                Object.Destroy(oldBuilding);
            }
        }
    }
}
