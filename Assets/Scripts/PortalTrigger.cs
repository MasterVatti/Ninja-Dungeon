using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала)
/// </summary>
public class PortalTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _portalScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _portalScreen.SetActive(true);
        }
    }
}