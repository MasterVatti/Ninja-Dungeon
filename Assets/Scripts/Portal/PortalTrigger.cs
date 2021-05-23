using System;
using Assets.Scripts;
using BuildingSystem;
using SaveSystem;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) 
/// </summary>
public class PortalTrigger : MonoBehaviour
{
    private ExperienceView _experienceView;
    private LevelTolerance _levelTolerance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG) && _levelTolerance.LevelUnlock == Convert.ToInt32(_experienceView.LevelPlayer.text))
        {
            GetComponent<IPortalScreenOpener>().ShowPortalScreen();
        }
    }
}