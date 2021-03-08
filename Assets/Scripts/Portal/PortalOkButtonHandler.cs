using LoadingScene;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Этот класс обрабатывает нажатие кнопки Yes на Portal Screen
    /// </summary>
    public class PortalOkButtonHandler : OkButtonHandler
    {
        [SerializeField]
        private Button _okButton;
        private string _sceneName;
        
        private void Start()
        {
            _okButton.onClick.AddListener(OnClick);
            
        }

        public override void OnClick()
        {
            ScreenManager.Instance.CloseTopScreen();
            LoadingController.Instance.StartLoad(_sceneName);
        }

        public void Initialize(string sceneName)
        {
            _sceneName = sceneName;
        }
    }
}