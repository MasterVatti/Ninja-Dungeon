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
            MainManager.ScreenManager.CloseTopScreen();
            Time.timeScale = 1;
        }
    }
}
