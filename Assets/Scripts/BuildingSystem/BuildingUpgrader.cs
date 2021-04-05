namespace BuildingSystem
{
    public class BuildingUpgrader
    {
        public bool UpgradeBuilding(BuildingSettings buildingSettings, int upgradeLevel)
        {
            if (buildingSettings.UpgradeList.Count > upgradeLevel)
            {
                var upgrade = buildingSettings.UpgradeList[upgradeLevel];
                var upgradeCost = upgrade.UpgradeCost;
                if (upgradeCost.TrueForAll(resource =>
                    MainManager.ResourceManager.HasEnough(resource.Type, resource.Amount)))
                {
                    upgradeCost.ForEach(resource => 
                        MainManager.ResourceManager.Pay(resource.Type, resource.Amount));
                    var go = BuildingController.CreateNewConstruction(buildingSettings, true, upgradeLevel);
                    go.GetComponent<IUpgradable>().CurrentBuildingLevel = upgradeLevel;
                    return true;
                }
            }

            return false;
        }
    }
}
