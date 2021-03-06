using Assets.Scripts.Managers.ScreensManager;
using Door;
using JetBrains.Annotations;
using NinjaDungeon.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaDungeon.Scripts.Portal
{
    /// <summary>
    /// Класс отвечает за окно портала(предложение спустится в инст и наоборот) и обработку кнопки Yes
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class PortalScreen : DungeonScreenTransition
    {
        [SerializeField]
        private Text _descriptionField;
        [SerializeField]
        private int _energyCost;
        [SerializeField]
        private TextMeshProUGUI _textEnertyCost;

        private PortalAnimatorController _portalAnimatorController;
    
        private void Start()
        {
            var animator = GetComponent<Animator>();
            _portalAnimatorController = new PortalAnimatorController(animator);

            _textEnertyCost.text = _energyCost.ToString();

            _portalAnimatorController.ChangeButtonColor(MainManager.EnergyManager.HasEnoughEnergy(_energyCost));
        }
    
        [UsedImplicitly]
        public override void OnClick()
        {
            if (MainManager.EnergyManager.HasEnoughEnergy(_energyCost))
            {
                MainManager.SaveLoadManager.SaveAll();
                TransitionStage();
            }
            else
            {
                MainManager.ScreenManager.CloseTopScreen();
                MainManager.ScreenManager.OpenScreen(ScreenType.InsufficientEnergy);
            }
        }

        public override void ApplyContext(PortalContext context)
        {
            base.ApplyContext(context);
            _descriptionField.text = context.Description;
        }
    
        protected override void TransitionStage()
        {
            base.TransitionStage();
        
            MainManager.EnergyManager.DecreaseEnergy(_energyCost);
        }
    }
}