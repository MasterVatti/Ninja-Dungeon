using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// закрыть экран
    /// </summary>
    public class ScreenClosing : MonoBehaviour
    {
        public void OnClick()
        {
            CloseSettingsScreen();
        }
        
        private void CloseSettingsScreen()
        {
            ScreenManager.Instance.CloseTopScreen();
            Time.timeScale = 1;
        }
    }
}
