using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{/// <summary>
 /// Класс отвечает за оприделение камеры
 /// </summary>
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _cameraCity;
        [SerializeField] 
        private GameObject _cameraDungeon;
        [SerializeField] 
        private string _sceneNameStart;
        private string _currentNameScene;
        private string _sceneName;

        private void Start()
        {
            _currentNameScene = _sceneNameStart;
        }

        void Update()
        {
            _sceneName = SceneManager.GetActiveScene().name;
            if (_currentNameScene != _sceneName)
            {
                CameraDefinition();
                _currentNameScene = _sceneName;
            }
            
        }

        private void CameraDefinition()
        {
            if (_sceneName == _sceneNameStart)
            {
                _cameraCity.SetActive(true);
                _cameraDungeon.SetActive(false);
            }
            else
            {
                _cameraCity.SetActive(false);
                _cameraDungeon.SetActive(true);
            }
        }
    }
}
