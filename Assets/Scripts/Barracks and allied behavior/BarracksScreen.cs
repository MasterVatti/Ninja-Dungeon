using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;
using UnityEngine.UI;

namespace Barracks_and_allied_behavior
{
    public class BarracksScreen : BaseScreen
    {
        [SerializeField]
        private List<Button> _buttons;
        [SerializeField]
        private List<Text> _descriptions;
        [SerializeField]
        private List<Text> _prices;
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
