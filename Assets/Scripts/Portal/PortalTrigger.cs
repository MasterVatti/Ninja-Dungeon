using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечает за тригер портала(вызов панели портала) и запуск загрузки сцены.
/// </summary>
public class PortalTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _portalScreen;
    [SerializeField]
    private PortalSettings _settings;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _portalScreen.GetComponent<PortalScreen>().Initialize(_settings);
            _portalScreen.SetActive(true);
        }
    }
    
    public void StartLoading()
    {
        _portalScreen.SetActive(false);
        LoadingController.Instance.StartLoad(_settings.SceneName);
    }
}