using Characteristics;
using Enemies;
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
    public static ScreenManager ScreenManager => Instance._screenManager;
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
    private ScreenManager _screenManager;
    [SerializeField]
    private Player _player; 
    [SerializeField]
    private IconsProvider _iconsProvider;
    [SerializeField]
    private Vector3 _spawnPositionPlayer;
    
    private void Awake()
    {
        _player = Instantiate(_player);
        _player.gameObject.SetActive(false);
    }

    public void ResetPlayer()
    {
        Player.BuffManager.StopBuff();
            
        var characteristics = (PlayerCharacteristics)Player.PersonCharacteristics;
        characteristics.CurrentHp = characteristics.MaxHp;
        characteristics.LevelDungeon = 0;
        characteristics.ExperienceDungeon = 0;
        
        Player.gameObject.SetActive(true);
        Player.transform.localPosition = _spawnPositionPlayer;
        Player.transform.rotation = Quaternion.identity;
    }
}
