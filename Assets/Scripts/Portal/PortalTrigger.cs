using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using Assets.Scripts.Managers.ScreensManager.Preview.RewardScreen;
using JetBrains.Annotations;
using LoadingScene;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) и передачу настроек портала.
/// </summary>
public class PortalTrigger : MonoBehaviour
{
    [SerializeField]
    private PortalSettings _settings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            var context = new PortalContext() {Description = _settings.ScreenDescription, SceneName = _settings.SceneName};
            ScreenManager.Instance.OpenScreenWithContext(ScreenType.PortalScreen,
                context);
        }
    }
}