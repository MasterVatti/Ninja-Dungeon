using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// открытие экрана настроек
    /// </summary>
    public class SettingsScreenOpener : MonoBehaviour
    {
        [UsedImplicitly]
        public void OpenSettingsScreen()
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.SettingsScreen);
            Time.timeScale = 0;
        }
    }
}
