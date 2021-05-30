using Assets.Scripts.Managers.ScreensManager;
using Buildings;
using BuildingSystem.BuildingUpgradeSystem;
using SaveSystem;

namespace BuildingSystem
{
    public abstract class UpgradableBuilding<T> : Building<T>, IUpgradable<T> where T : BaseBuildingState
    {
        public IBuilding Upgrade()
        {
            return BuildingUpgradeHelper.Upgrade(this);
        }
        public virtual void OnUpgrade(T oldBuildingState)
        {
            const string title = "Congratulations!";
            var message = $"You had improved {nameof(Tower)} to level {CurrentBuildingLevel}";
            var context = new InformationScreenContext(title, message);
            MainManager.ScreenManager.OpenScreenWithContext(ScreenType.InformationPopupScreen, context);
        }
        protected abstract override void OnStateLoaded(T data);
        public abstract override T GetState();
    }
}
