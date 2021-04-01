using System.Collections.Generic;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Базовый класс для всех зданий, у которых есть какой-то функционал
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Building<T> : MonoBehaviour, IBuilding where T : BuildingData
    {
        protected T state;
        public abstract void Initialize(Dictionary<object, object> savedState);

        public virtual BuildingData Save()
        {
           return GetBuildingData();
        }

        protected abstract T GetBuildingData();

        private void OnDestroy()
        {
            MainManager.BuildingManager.ActiveBuildings.Remove(gameObject);
        }
    }
}
