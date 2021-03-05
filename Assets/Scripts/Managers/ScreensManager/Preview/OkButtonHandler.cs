using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager.Preview
{
    /// <summary>
    /// Класс работает для обработки нажатия кнопки ОК в RewardScreen
    /// Учитывая, что синглтон еще не в мейне, пока что ищу менеджер
    /// просто по названию, так как получить по другому из префаба не могу 
    /// </summary>
    public class OkButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private Button _okButton;

        private ScreenManager _screenManager;

        private void Start()
        {
            if (_screenManager == null)
            {
                _screenManager = GameObject.Find("ScreenManager")
                    .GetComponent<ScreenManager>();
            }
            
            Button button = _okButton.GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _screenManager.CloseTopScreen();
        }
    }
}
