using Assets.Scripts;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) 
/// </summary>
public class ScreenWithContextOpenerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            GetComponent<IScreenOpenerWithContext>().ShowScreenWithContext();
        }
    }
}