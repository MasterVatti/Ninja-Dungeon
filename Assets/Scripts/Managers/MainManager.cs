using Characteristics;
using Enemies;
using LoadingScene;
using Managers;
using Managers.ScreensManager;
using PlayerScripts;
using PlayerScripts.Movement;
using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    public static LoadingController LoadingController => Instance._loadingController;
    public static ResourceManager ResourceManager => Instance._resourceManager;
    public static EnemiesManager EnemiesManager => Instance._enemiesManager;
    public static ScreenManager ScreenManager => Instance._screenManager;
    public static AnimationManager AnimationManager => Instance._animationManager;
    public static BuildingManager BuildingManager => Instance._buildingManager;
    public static PlayerMovementController PlayerMovementController => Instance._playerMovementController;
    public static SaveLoadManager SaveLoadManager => Instance._saveLoadManager;
    public static GameObject Player => Instance._player;
    public static IconsProvider IconsProvider => Instance._iconsProvider;
    public static JoystickController JoystickController => Instance._joystickController;
    public static UserData UserData => Instance._userData;
    public static CharacteristicList CharacteristicList => Instance._characteristicList;
    
    [SerializeField]
    private JoystickController _joystickController;
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
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private SaveLoadManager _saveLoadManager;
    [SerializeField]
    private GameObject _player; 
    [SerializeField]
    private IconsProvider _iconsProvider;
    [SerializeField]
    private UserData _userData;
    [SerializeField]
    private CharacteristicList _characteristicList;

}
