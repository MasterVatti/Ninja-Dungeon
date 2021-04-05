namespace BuildingSystem
{
    /// <summary>
    /// интерфейс для реализации улучшений уровня зданий
    /// </summary>
    public interface IUpgradable
    {
        /// <summary>
        /// Текущий уровень здания
        /// </summary>
        int CurrentBuildingLevel { get; set; }
        /// <summary>
        /// Класс, содрежащий метод базовую логику улучшения
        /// </summary>
        BuildingUpgrader Upgrader { get; set; }
        /// <summary>
        /// Метод использующий и расширяющий базовую логику улучшения здания
        /// </summary>
        void Upgrade();
    }
}
