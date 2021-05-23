using BuffSystem;
using Characteristics;
using Enemies;
using Energy;
using LoadingScene;
using Managers;
using Managers.ScreensManager;
using PlayerScripts.Movement;
using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    public static LoadingController LoadingController => Instance._loadingController;
    public static ResourceManager ResourceManager => Instance._resourceManager;
    public static EnemiesManager EnemiesManager => Instance._enemiesManager;
    public static EnergyManager EnergyManager => Instance._energyManager;
    public static ScreenManager ScreenManager => Instance._screenManager;
    public static AnimationManager AnimationManager => Instance._animationManager;
    public static BuildingManager BuildingManager => Instance._buildingManager;
    public static PlayerMovementController PlayerMovementController => Instance._playerMovementController;
    public static SaveLoadManager SaveLoadManager => Instance._saveLoadManager;
    public static Player Player => Instance._player;
    public static IconsProvider IconsProvider => Instance._iconsProvider;
    public static JoystickController JoystickController => Instance._joystickController;

    [SerializeField]
    private JoystickController _joystickController;
    [SerializeField]
    private LoadingController _loadingController;
    [SerializeField]
    private ResourceManager _resourceManager;
    [SerializeField]
    private EnemiesManager _enemiesManager;
    [SerializeField]
    private EnergyManager _energyManager;
    [SerializeField]
    private ScreenManager _screenManager;   
    [SerializeField]
    private AnimationManager _animationManager;    
    [SerializeField]
    private BuildingManager _buildingManager; 
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private SaveLoadManager _saveLoadManager;
    [SerializeField]
    private Player _player; 
    [SerializeField]
    private IconsProvider _iconsProvider;
}
