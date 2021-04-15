namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// интерфейс для улучшений уровня зданий
    /// </summary>
    public interface IUpgradable
    {
        int CurrentBuildingLevel { get; set; }
        void Upgrade();
    }
}
