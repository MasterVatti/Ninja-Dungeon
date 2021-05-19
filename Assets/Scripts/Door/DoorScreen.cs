using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using LoadingScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    /// <summary>
    /// Класс отвечает за окно двери(предложение отправиться в комнату) и обработку кнопок
    /// </summary>
    public class DoorScreen : BaseScreenWithContext<PortalContext>
    {
        [SerializeField]
        private Text _descriptionField;
        [SerializeField]
        private Text _difficultyLevelField;
        private string _sceneName;

        [UsedImplicitly]
        public void TurnOffPanel()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }

        public override void ApplyContext(PortalContext context)
        {
            _descriptionField.text = context.Description;
            _difficultyLevelField.text = context.DifficultyLevel;
            _sceneName = context.SceneName;
        }

        public void OnClick()
        {
            MainManager.ScreenManager.CloseTopScreen();
            MainManager.LoadingController.StartLoad(_sceneName);
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}