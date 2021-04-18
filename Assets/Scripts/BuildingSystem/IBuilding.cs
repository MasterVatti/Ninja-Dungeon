using SaveSystem;

namespace BuildingSystem
{
    public interface IStatefulBuilding<T> : IBuilding where T : BaseBuildingState
    {
        public abstract void OnUpgrade(T oldBuildingState);
        public abstract T GetState();
    }
    
    /// <summary>
    /// Интерфейс для инициализации сохраненных данных и сохранения данных
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
