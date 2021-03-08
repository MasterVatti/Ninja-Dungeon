using Assets.Scripts;
using LoadingScene;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) и запуск загрузки сцены.
/// </summary>
public class PortalTrigger : MonoBehaviour
{
    [SerializeField]
    private PortalScreen _portalScreen;
    [SerializeField]
    private PortalSettings _settings;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            _portalScreen.Initialize(_settings);
            _portalScreen.gameObject.SetActive(true);
        }
    }
    
    public void StartLoading()
    {
        _portalScreen.gameObject.SetActive(false);
        LoadingController.Instance.StartLoad(_settings.SceneName);
    }
}