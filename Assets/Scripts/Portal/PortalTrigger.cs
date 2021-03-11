using Assets.Scripts;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) и передачу настроек портала.
/// </summary>
public class PortalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            GetComponent<IPortalScreenOpener>().ShowPortalScreen();
        }
    }
}