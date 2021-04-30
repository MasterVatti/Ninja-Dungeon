using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Settings
{
    public class SettingsScreenOpener : MonoBehaviour
    {
        public void OnClick()
        {
            OpenSettingsScreen();
        }
    
        private void OpenSettingsScreen()
        {
            ScreenManager.Instance.OpenScreen(ScreenType.SettingsScreen);
            Time.timeScale = 0;
        }
    }
}
