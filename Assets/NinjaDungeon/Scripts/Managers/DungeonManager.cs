using Assets.Scripts;
using NinjaDungeon.Scripts.BattleManager;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DungeonManager : Singleton<DungeonManager>
{
    public static BattleManager BattleManager => Instance._battleManager;
        
    [SerializeField]
    private BattleManager _battleManager;
    
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

