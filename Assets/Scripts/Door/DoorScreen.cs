using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using LoadingScene;
using Managers.ScreensManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    /// <summary>
    /// Класс отвечает за окно двери(предложение отправиться в комнату) и обработку кнопок
    /// TODO : make base class for PortalScreen and DoorScreen
    /// </summary>
    public class DoorScreen : BaseScreenWithContext<PortalContext>
    {
        [SerializeField]
        private int _energyCost;
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
            if (MainManager.EnergyManager.HasEnoughEnergy(_energyCost))
            {
                MainManager.ScreenManager.CloseTopScreen();
                MainManager.LoadingController.StartLoad(_sceneName);
                MainManager.EnergyManager.DecreaseEnergy(_energyCost);
            }
            else
            {
                MainManager.ScreenManager.OpenScreenWithContext(ScreenType.InformationPopupScreen, 
                    new InformationScreenContext("Energy Warning", "You don't have enough energy"));
            }
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}