using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    /// <summary>
    /// Класс отвечает за окно двери(предложение отправиться в комнату) и обработку кнопок
    /// </summary>
    public class DoorScreen : DungeonScreenTransition
    {
        [SerializeField]
        private Text _difficultyLevelField;
        
        public override void ApplyContext(PortalContext context)
        {
            base.ApplyContext(context);
            _difficultyLevelField.text = context.DifficultyLevel;
        }

        [UsedImplicitly]
        public override void OnClick()
        {
            TransitionStage();
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}