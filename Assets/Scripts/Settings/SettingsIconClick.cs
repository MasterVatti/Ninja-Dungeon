using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

public class SettingsIconClick : MonoBehaviour
{
    
    private void OpenSettingsScreen()
    {
        var context = new PortalContext
        {
            Description = "_settings.ScreenDescription, ",
            SceneName = "Settings"
        };
        ScreenManager.Instance.OpenScreenWithContext(ScreenType
            .SettingsScreen, context);
    }
    
    public void OnClick()
    {
        OpenSettingsScreen();
    }
}
