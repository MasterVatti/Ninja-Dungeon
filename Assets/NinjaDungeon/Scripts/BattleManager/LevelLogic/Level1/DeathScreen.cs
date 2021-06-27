using Assets.Scripts.Managers.ScreensManager;
using Door;
using JetBrains.Annotations;

namespace NinjaDungeon.Scripts.BattleManager.LevelLogic.Level1
{
    public class DeathScreen : DungeonScreenTransition
    {
        [UsedImplicitly]
        public override void OnClick()
        {
            MainManager.BattleManager.ClearLevel();
            MainManager.LoadingController.StartLoad(_sceneName);
        }

        public override void ApplyContext(PortalContext context)
        {
            _sceneName = context.SceneName;
        }
    }
}