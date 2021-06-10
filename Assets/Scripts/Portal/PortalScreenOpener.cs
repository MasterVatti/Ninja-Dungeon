using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

/// <summary>
/// Класс отвечает за открытие окна портала
/// </summary>
public class PortalScreenOpener : MonoBehaviour, IScreenOpenerWithContext
{
    [SerializeField]
    private PortalSettings _settings;

    public  void ShowScreenWithContext()
    {
        var context = new PortalContext()
        {
            Description = _settings.ScreenDescription,
            SceneName = _settings.SceneName,
            TeleportPosition = _settings.TeleportPosition
        };

        MainManager.ScreenManager.OpenScreenWithContext(ScreenType.PortalScreen,
            context);
    }
}