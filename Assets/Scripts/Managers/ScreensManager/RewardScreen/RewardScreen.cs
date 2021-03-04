using UnityEngine;
using UnityEngine.UI;

namespace Managers.ScreensManager
{
    public class RewardScreen: BaseScreen
    {
        [SerializeField]
        private Text _goldLabel;
        
        public override void Initialize<TRewardScreenContext>(ScreenType type, 
            TRewardScreenContext screenContext)
        {
            ScreenType = type;
            Context = screenContext;
            Debug.Log($"HERE, context {Context}");
        }
    }
}
