using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// открытие экрана настроек
    /// </summary>
    public class SettingsScreenOpener : MonoBehaviour
    {
        public void OnClick()
        {
            OpenSettingsScreen();
        }
    
        private void OpenSettingsScreen()
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.SettingsScreen);
            Time.timeScale = 0;
        }
    }
}
