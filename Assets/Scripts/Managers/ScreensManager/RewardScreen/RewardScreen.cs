using UnityEngine;
using UnityEngine.UI;

namespace Managers.ScreensManager
{
    public class RewardScreen: BaseScreen
    {
        [SerializeField]
        private Text _goldLabel;
        
        public void Initialize(ScreenType type, 
            BaseScreenContext screenContext)
        {
            ScreenType = type;
            Context = screenContext;
        }
    }
}
