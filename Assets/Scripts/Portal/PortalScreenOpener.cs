using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

/// <summary>
/// Класс отвечает за открытие окна портала
/// </summary>
public class PortalScreenOpener : MonoBehaviour, IPortalScreenOpener
{
    [SerializeField]
    private PortalSettings _settings;
    
    public void ShowPortalScreen()
    {
        var context = new PortalContext() 
        {
            Description = _settings.ScreenDescription, 
            SceneName = _settings.SceneName
        };
        ScreenManager.Instance.OpenScreenWithContext(ScreenType.DoorScreen,
            context);
    }
}
