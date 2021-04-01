using System;
using System.Collections.Generic;
using SaveSystem;

namespace BuildingSystem
{
    public interface IBuilding
    {
        void Initialize(Dictionary<object, object> savedState);
        BuildingData Save();
    }
}
