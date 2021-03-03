using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    
    /// <summary>
    /// Класс отвечает за окно загрузки меджу сценами
    /// </summary>
public class LoadingScreen : MonoBehaviour
{
    
    [SerializeField]
    private Slider _loadingProgressSlaider;
    [SerializeField]
    private GameObject _loadingScreen;

    public void LoadingScreenOfFade( int loadingScene)
    {
        StartCoroutine(LoadingScreenFade(loadingScene));
    }
     IEnumerator LoadingScreenFade(int loadingScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadingScene);
        _loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .9f);
            _loadingProgressSlaider.value = progress;
            yield return null;
        }
    }
}
