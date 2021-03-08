using System;
using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingScene 
{
    /// <summary>
    /// Класс отвечает за окно загрузки меджу сценами.
    /// </summary>
    public class LoadingScreen : BaseScreen
    {
        [SerializeField]
        private Slider _loadingProgress;
        private LoadingController _loadingController;
        
        private void Awake()
        {
            _loadingController = GetComponentInParent<LoadingController>();
        }

        private void Update()
        {
            _loadingProgress.value = _loadingController.LoadingProgress;
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}