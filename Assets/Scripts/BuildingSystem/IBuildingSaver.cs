using SaveSystem;

namespace BuildingSystem
{
    /// <summary>
    /// Интерфейс для инициализации сохраненных данных и сохранения данных
    /// </summary>
    public interface IBuildingSaver
    {
        int BuildingSettingsID { set; }
        void Initialize(string savedData);
        void Initialize(int buildingSettingsID);
        BuildingData Save();
    }
}
