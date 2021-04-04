using Assets.Scripts.Managers.ScreensManager;
using Enemies;
using LoadingScene;
using Managers;
using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    public static BuildingManager BuildingManager => Instance._buildingManager;
    public static LoadingController LoadingController => Instance._loadingController;
    public static ResourceManager ResourceManager => Instance._resourceManager;
    public static EnemiesManager EnemiesManager => Instance._enemiesManager;
    public static ScreenManager ScreenManager => Instance._screenManager;
    public static AnimationManager AnimationManager => Instance._animationManager;
  
    [SerializeField]
    private LoadingController _loadingController;
    [SerializeField]
    private ResourceManager _resourceManager;
    [SerializeField]
    private EnemiesManager _enemiesManager;
    [SerializeField]
    private ScreenManager _screenManager;   
    [SerializeField]
    private AnimationManager _animationManager;    
    [SerializeField]
    private BuildingManager _buildingManager;
}
