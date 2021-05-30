using SaveSystem;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public interface IUpgradable<T> where T : BaseBuildingState
    {
        IBuilding Upgrade();
        void OnUpgrade(T oldBuildingState);
    }
}
