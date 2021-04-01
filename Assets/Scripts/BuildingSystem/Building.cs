using System.Collections.Generic;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem
{
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
