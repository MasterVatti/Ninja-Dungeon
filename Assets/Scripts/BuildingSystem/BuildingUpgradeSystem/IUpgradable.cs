using SaveSystem;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public interface IUpgradable<T> where T : BaseBuildingState
    {
        void OnUpgrade(T oldBuildingState);
    }
}
