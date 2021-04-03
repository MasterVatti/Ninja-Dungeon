using SaveSystem;

namespace BuildingSystem
{
    /// <summary>
    /// Интерфейс для инициализации сохраненных данных и сохранения данных
    /// </summary>
    public interface IBuilding
    {
        int BuildingSettingsID { set; }
        void Initialize(string savedData);
        BuildingData Save();
    }
}
