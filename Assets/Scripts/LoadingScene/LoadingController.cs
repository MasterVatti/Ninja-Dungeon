using System.Collections;
using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadingScene 
{
    /// <summary>
    /// Класс отвечает за  загрузку сцены.
    /// </summary>
    public class LoadingController : Singleton<LoadingController>
    {
        public float LoadingProgress { get; private set; }
        
        public void StartLoad(string sceneName)
        {
            
            ScreenManager.Instance.OpenScreen(ScreenType.LoadingScreen);
            
            StartCoroutine(LoadCoroutine(sceneName));
        }
        
        private IEnumerator LoadCoroutine(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                LoadingProgress = Mathf.Clamp01(operation.progress / 1f);
                yield return null;
            }
            
            ScreenManager.Instance.CloseTopScreen();
        }
    }
}