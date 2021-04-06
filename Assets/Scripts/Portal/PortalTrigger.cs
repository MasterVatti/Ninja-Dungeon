using Assets.Scripts;
using BuildingSystem;
using SaveSystem;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) 
/// </summary>
public class PortalTrigger : Building<PortalData>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            GetComponent<IPortalScreenOpener>().ShowPortalScreen();
        }
    }
    
    protected override void Initialize(PortalData data)
    {
    }
}