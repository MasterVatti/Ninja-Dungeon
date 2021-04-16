using SaveSystem;

namespace BuildingSystem
{
    /// <summary>
    /// Интерфейс для инициализации сохраненных данных и сохранения данных
    /// </summary>
    public interface IBuilding
    {
        int BuildingSettingsID { set; }
        public int CurrentBuildingLevel { get; set; }
        void Initialize(string savedData);
        void Initialize(int buildingSettingsID);
        BuildingData Save();
    }
}
