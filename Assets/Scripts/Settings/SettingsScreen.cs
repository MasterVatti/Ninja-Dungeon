using Assets.Scripts.Managers.ScreensManager;

namespace Settings
{
    public class SettingsScreen : BaseScreen
    {
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
