using Assets.Scripts;
using Energy;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NinjaDungeon.Scripts.Managers
{
    public class UpperWorldManager : Singleton<UpperWorldManager>
    {
        public static AnimationManager AnimationManager => Instance._animationManager;
        public static BuildingManager BuildingManager => Instance._buildingManager;
        public static SaveLoadManager SaveLoadManager => Instance._saveLoadManager;

        [SerializeField]
        private SaveLoadManager _saveLoadManager;
        [SerializeField]
        private AnimationManager _animationManager;    
        [SerializeField]
        private BuildingManager _buildingManager;

        private void Start()
        {
            SceneManager.sceneLoaded += GoToDungeon;
        }

        private void GoToDungeon(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (GlobalConstants.MAIN_SCENE_TAG != scene.name)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= GoToDungeon;
        }
    }
}
