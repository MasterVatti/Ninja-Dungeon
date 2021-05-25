using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    /// <summary>
    /// Базовый класс для перехода в подземелья/внутри подземелья
    /// </summary>
    public abstract class DungeonScreenTransition : BaseScreenWithContext<PortalContext>
    {
        [SerializeField]
        private Text _descriptionField;

        private string _sceneName;
        private Vector3 _teleportPosition;
        
        [UsedImplicitly]
        public void TurnOffPanel()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }

        [UsedImplicitly]
        public abstract void OnClick();

        public override void ApplyContext(PortalContext context)
        {
            _descriptionField.text = context.Description;
            _sceneName = context.SceneName;
            _teleportPosition = context.TeleportPosition;
        }
        
        protected virtual void TransitionStage()
        {
            MainManager.ScreenManager.CloseTopScreen();
            MainManager.LoadingController.StartLoad(_sceneName);
            MainManager.Player.transform.position = _teleportPosition;
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
