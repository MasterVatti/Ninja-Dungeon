using Assets.Scripts.Managers.ScreensManager;
using SaveSystem;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeContext<T> : BaseContext where T : BaseBuildingState
    {
        public Building<T> Building { get; set; }
    }
}
