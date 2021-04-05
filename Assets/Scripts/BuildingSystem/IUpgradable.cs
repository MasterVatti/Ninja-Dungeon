namespace BuildingSystem
{
    public interface IUpgradable
    {
        int CurrentBuildingLevel { get; set; }

        BuildingUpgrader Upgrader { get; set; }
    }
}
