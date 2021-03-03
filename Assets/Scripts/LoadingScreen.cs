using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Класс отвечает за окно загрузки меджу сценами.
/// </summary>
public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Slider _progressLoadingSlider;
    [SerializeField]
    private GameObject _loadingScreen;

    public void TurnOnLoadingScreen(int loadingScene)
    {
        StartCoroutine(LoadingScreenCoroutine(loadingScene));
    }

    IEnumerator LoadingScreenCoroutine(int loadingScene)
    {
        var operation = SceneManager.LoadSceneAsync(loadingScene);
        _loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .9f);
            _progressLoadingSlider.value = progress;
            yield return null;
        }
    }
}