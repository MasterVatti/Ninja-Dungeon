using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager.Preview
{
    /// <summary>
    /// Класс работает для обработки нажатия кнопки ОК в RewardScreen
    /// Учитывая, что синглтон еще не в мейне, пока что ищу менеджер
    /// просто по названию, так как получить по другому из префаба не могу 
    /// </summary>
    public class OkButtonScript : MonoBehaviour
    {
        [SerializeField]
        private Button _okButton;

        private ScreenManager _screenManager;

        private void Start()
        {
            Button btn = _okButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick()
        {
            if (_screenManager == null)
            {
                _screenManager = GameObject.Find("ScreenManager")
                    .GetComponent<ScreenManager>();
            }

            _screenManager.CloseUpperScreen();
        }
    }
}
