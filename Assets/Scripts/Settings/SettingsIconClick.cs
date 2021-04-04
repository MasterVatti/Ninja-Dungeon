using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

public class SettingsIconClick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OpenSettingsScreen()
    {
        var context = new PortalContext()
        {
            Description = "_settings.ScreenDescription, ",
            SceneName = "Settings"
        };
        ScreenManager.Instance.OpenScreenWithContext(ScreenType
            .DoorScreen, context);
    }
    
    public void OnClick()
    {
        OpenSettingsScreen();
    }
}
