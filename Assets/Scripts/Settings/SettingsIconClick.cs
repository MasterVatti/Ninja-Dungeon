using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

public class SettingsIconClick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OpenSettingsScreen()
    {
        var context = new SettingsContext
        {
            firstSetting = "Настройки"
        };
        ScreenManager.Instance.OpenScreenWithContext(ScreenType
            .PortalScreen, context);
    }
    public void OnClick()
    {
        OpenSettingsScreen();
    }
}
