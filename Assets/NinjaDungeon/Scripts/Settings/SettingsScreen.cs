using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;

namespace Settings
{
    public class SettingsScreen : BaseScreen
    {
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
        
        [UsedImplicitly]
        public void CloseSettingsScreen()
        {
            MainManager.ScreenManager.CloseTopScreen();
            Time.timeScale = 1;
        }
    }
}
