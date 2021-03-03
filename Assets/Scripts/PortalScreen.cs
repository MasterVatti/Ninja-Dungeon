using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс отвечает за окно портала(предложение спустится в инст и наоборот)
/// </summary>
public class PortalScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _portalScreen;

    [SerializeField]
    private TMP_Text _descriptionField;

    [SerializeField]
    private string _screenDescription;

    private void Awake()
    {
        _descriptionField.text = _screenDescription;
    }

    [UsedImplicitly]
    public void TurnOffPanel()
    {
        _portalScreen.SetActive(false);
    }
    
}
