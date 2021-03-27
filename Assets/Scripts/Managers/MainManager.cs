using Assets.Scripts.Managers.ScreensManager;
using Enemies;
using LoadingScene;
using Managers;
using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    public static LoadingController LoadingController => _loadingController;
    public static ResourceManager ResourceManager => _resourceManager;
    public static EnemiesManager EnemiesManager => _enemiesManager;
    public static ScreenManager ScreenManager => _screenManager;
    
    [SerializeField]
    private static LoadingController _loadingController;
    [SerializeField]
    private static ResourceManager _resourceManager;
    [SerializeField]
    private static EnemiesManager _enemiesManager;
    [SerializeField]
    private static ScreenManager _screenManager;
}
