using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс отвечает за затемнение и загрузку сцены.
/// </summary>
public class LoadingController : MonoBehaviour
{
    [SerializeField]
    private LoadingScreen _loadingScreen;
    [SerializeField]
    private int _loadingSceneNumber;
    
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    [UsedImplicitly]
    public void FadeToLevel()
    {
        _animator.SetTrigger("Fade");
    }

    [UsedImplicitly]
    public void LoadingScene()
    {
        SceneManager.LoadScene(_loadingSceneNumber);
        _loadingScreen.TurnOnLoadingScreen(_loadingSceneNumber);
    }
}