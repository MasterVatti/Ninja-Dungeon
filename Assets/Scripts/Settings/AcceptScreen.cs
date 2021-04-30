using Assets.Scripts.Managers.ScreensManager;

namespace Settings
{
    /// <summary>
    /// экран подтверждения выхода из игры
    /// </summary>
    public class AcceptScreen : BaseScreen
    {
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
