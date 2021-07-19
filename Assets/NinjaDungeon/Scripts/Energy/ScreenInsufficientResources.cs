using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;

namespace Energy
{
    public class ScreenInsufficientResources : BaseScreen
    {
        [UsedImplicitly]
        public void OnClick()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
