using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;

namespace Assets.Scripts.BattleManager.Level1
{
    public class DeathScreen : BaseScreen
    {
        [UsedImplicitly]
        public void TurnOffPanel()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        public void GoToUpperWorld()
        {
            MainManager.LoadingController.StartLoad(GlobalConstants.MAIN_SCENE_TAG);
        }
    }
}