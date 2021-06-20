using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using DefaultNamespace;
using JetBrains.Annotations;

namespace NinjaDungeon.Scripts.BattleManager.LevelLogic.Level1
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
            EventBus.Publish<ISpawnHandler>(spawner => spawner.EndSpawn());
            MainManager.EnemiesManager.Enemies.Clear();
            
            MainManager.LoadingController.StartLoad(GlobalConstants.MAIN_SCENE_TAG);
        }
    }
}