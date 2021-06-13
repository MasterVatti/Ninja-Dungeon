using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingScene 
{
    /// <summary>
    /// Класс отвечает за окно загрузки между сценами.
    /// </summary>
    public class LoadingScreen : BaseScreen
    {
        [SerializeField]
        private Slider _loadingProgress;
        
        private void Update()
        {
            _loadingProgress.value =  MainManager.LoadingController.LoadingProgress;
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}