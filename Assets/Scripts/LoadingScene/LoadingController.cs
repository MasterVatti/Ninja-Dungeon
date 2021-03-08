using System.Collections;
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
    
        [SerializeField]
        private LoadingScreen _loadingScreen;
        
        public void StartLoad(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            StartCoroutine(LoadCoroutine(sceneName));
        }

        private IEnumerator LoadCoroutine(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            
            _loadingScreen.gameObject.SetActive(true);
            while (!operation.isDone)
            {
                LoadingProgress = Mathf.Clamp01(operation.progress / 1f);
                yield return null;
            }
            
            _loadingScreen.gameObject.SetActive(false);
        }
    }
}