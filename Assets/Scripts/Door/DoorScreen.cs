using System;
using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using LoadingScene;
using TMPro;
using UnityEngine;

namespace Door
{
    /// <summary>
    /// Класс отвечает за окно двери(предложение отправиться в комнату) и обработку кнопок
    /// </summary>
    public class DoorScreen : BaseScreenWithContext<PortalContext>
    {
        [SerializeField]
        private TMP_Text _descriptionField;
        [SerializeField]
        private TMP_Text _difficultyLevelField;
        [SerializeField] 
        private EnergyManager _energyManager;

        [SerializeField]
        private int _energyDecreaseCount = 35;
        private string _sceneName;

        [UsedImplicitly]
        public void TurnOffPanel()
        {
            ScreenManager.Instance.CloseTopScreen();
        }

        public override void ApplyContext(PortalContext context)
        {
            _descriptionField.text = context.Description;
            _difficultyLevelField.text = context.DifficultyLevel;
            _sceneName = context.SceneName;
        }

        public void OnClick()
        {
            if (_energyManager.Energy >= _energyDecreaseCount)
            {
                _energyManager.EnergyDecrease(_energyDecreaseCount);
                ScreenManager.Instance.CloseTopScreen();
                LoadingController.Instance.StartLoad(_sceneName);
            }
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}