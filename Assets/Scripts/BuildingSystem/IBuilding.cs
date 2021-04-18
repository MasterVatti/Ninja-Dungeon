using SaveSystem;

namespace BuildingSystem
{ /// <summary>
    /// Интерфейс для реализации зданий
    /// </summary>
    public interface IBuilding
    {
        public int CurrentBuildingLevel { get; }
        public int BuildingSettingsID { get; }
        
        void LoadState(string savedData);
        void Initialize(int buildingSettingsID, int level);
        IBuilding Upgrade();

        BuildingData Save();
    }
}
