using System.Collections.Generic;
using SaveSystem;

namespace BuildingSystem
{
    /// <summary>
    /// Интерфейс для инициализации сохраненных данных и сохранения данных
    /// </summary>
    public interface IBuilding
    {
        void Initialize(Dictionary<object, object> savedState);
        BuildingData Save();
    }
}
