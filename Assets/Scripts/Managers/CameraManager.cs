using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    /// <summary>
    /// Класс отвечает за оприделение камеры
    /// </summary>
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cameraCity;
        [SerializeField] private GameObject _cameraDungeon;
        [SerializeField] private string _sceneNameStart;
        private string _sceneName;

        private void Start()
        {
            CameraDefinition();
            SceneManager.sceneLoaded += OnSceneManagerOnSceneLoaded;
        }

        private void OnSceneManagerOnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            CameraDefinition();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneManagerOnSceneLoaded;
        }

        private void CameraDefinition()
        {
            _sceneName = SceneManager.GetActiveScene().name;
            if (_sceneName == _sceneNameStart)
            {
                _cameraDungeon.SetActive(false);
                _cameraCity.SetActive(true);
            }
            else
            {
                _cameraCity.SetActive(false);
                _cameraDungeon.SetActive(true);
            }
        }
    }
}
