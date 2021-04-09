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
            var context = new SettingsContext
            {
                FirstSettingText = "_settings.ScreenDescription, ",
                //SceneName = "Settings"
            };
            ScreenManager.Instance.OpenScreen/*WithContext*/(ScreenType
                .SettingsScreen/*, context*/);
        }
    }
}
