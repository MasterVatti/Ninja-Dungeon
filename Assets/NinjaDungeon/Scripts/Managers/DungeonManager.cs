using Assets.Scripts;
using Assets.Scripts.BattleManager;
using NinjaDungeon.Scripts.BattleManager;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DungeonManager : Singleton<DungeonManager>
{
    public static BattleManager BattleManager => Instance._battleManager;
    public static RewardManager RewardManager => Instance._rewardManager;

    [SerializeField]
    private BattleManager _battleManager;
    [SerializeField]
    private RewardManager _rewardManager;
    
    private void Start()
    {
        SceneManager.sceneLoaded += GoToUpperWorld;
    }

    private void GoToUpperWorld(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (GlobalConstants.MAIN_SCENE_TAG == scene.name)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= GoToUpperWorld;
    }
}

