using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager.Preview
{
    /// <summary>
    /// Класс работает для обработки нажатия кнопки ОК в RewardScreen
    /// </summary>
    public class RewardOkButtonHandler : OkButtonHandler
    {
        [SerializeField]
        private Button _okButton;
        
        private void Start()
        {
            _okButton.onClick.AddListener(OnClick);
        }

        public override void OnClick()
        {
            ScreenManager.Instance.CloseTopScreen();
        }
    }
}
