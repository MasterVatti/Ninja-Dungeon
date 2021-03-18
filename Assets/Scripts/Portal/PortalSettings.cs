using System;
using UnityEngine;

/// <summary>
/// Класс отвечает за настройки портала(куда отправится и описание)
/// </summary>
[Serializable]
public class PortalSettings
{
    public string ScreenDescription => _screenDescription;
    public string SceneName => _sceneName;
    
    [SerializeField]
    private string _screenDescription;
    [SerializeField]
    private string _sceneName;
    
}
