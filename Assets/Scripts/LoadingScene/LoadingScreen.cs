using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// Класс отвечает за окно загрузки меджу сценами.
/// </summary>
public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Slider _progressLoading;

    private void Update()
    {
        _progressLoading.value = LoadingController.Instance.LoadingProgress;
    }
}