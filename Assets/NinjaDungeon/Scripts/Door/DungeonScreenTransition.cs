using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using NinjaDungeon.Scripts.Characteristics;
using UnityEngine;

namespace Door
{
    /// <summary>
    /// Базовый класс для перехода в подземелья/внутри подземелья
    /// </summary>
    public abstract class DungeonScreenTransition : BaseScreenWithContext<PortalContext>
    {
        protected string _sceneName;
        protected Vector3 _teleportPosition;
        
        [UsedImplicitly]
        public void TurnOffPanel()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }

        [UsedImplicitly]
        public abstract void OnClick();

        public override void ApplyContext(PortalContext context)
        {
            _sceneName = context.SceneName;
            _teleportPosition = context.TeleportPosition;
        }
        
        protected virtual void TransitionStage()
        {
            MainManager.ScreenManager.CloseTopScreen();
            MainManager.LoadingController.StartLoad(_sceneName);
            MainManager.Player.transform.position = _teleportPosition;
            
            if (MainManager.Ally != null)
            {
                MainManager.Ally.PortingToPlayer(); 
            }
            
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
