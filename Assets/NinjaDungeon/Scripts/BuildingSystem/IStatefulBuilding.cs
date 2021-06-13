using SaveSystem;

namespace BuildingSystem
{
    /// <summary>
    /// Интерфейс для реализации апгрейдов зданий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStatefulBuilding<T> : IBuilding where T : BaseBuildingState
    {
        void OnUpgrade(T oldBuildingState);
        T GetState();
    }
}
