using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public interface IUpgrader
    {
        GameObject Upgrade(BuildingSettings settings, int buildingLevel);
    }
}