using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс отвечает за затемнение и загрузку сцены.
/// </summary>
public class LoadingController : Singleton<LoadingController>
{
    public float LoadingProgress { get; private set; }
    
    [SerializeField]
    private LoadingScreen _loadingScreen;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartLoad(string sceneName)
    {
        _animator.SetTrigger("Fade");
        StartCoroutine(LoadCoroutine(sceneName));
    }

    private IEnumerator LoadCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        
        var operation = SceneManager.LoadSceneAsync(sceneName);
        _loadingScreen.gameObject.SetActive(true);
        while (!operation.isDone)
        {
            LoadingProgress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }
}