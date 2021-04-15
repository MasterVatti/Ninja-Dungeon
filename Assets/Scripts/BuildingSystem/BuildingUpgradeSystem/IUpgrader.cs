using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public interface IUpgrader
    {
        GameObject Upgrade<T>(T state, BuildingSettings settings, int buildingLevel) where T : BaseBuildingState;
    }
}