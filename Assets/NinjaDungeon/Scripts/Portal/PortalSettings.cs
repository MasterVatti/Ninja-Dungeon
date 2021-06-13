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
    public Vector3 TeleportPosition => _teleportPosition;

    [SerializeField]
    private string _screenDescription;
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private Vector3 _teleportPosition;

}
