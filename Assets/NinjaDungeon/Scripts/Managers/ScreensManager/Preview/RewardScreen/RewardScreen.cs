using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager.Preview.RewardScreen
{
    /// <summary>
    /// Пример окна.
    /// В данном случае тестовое окно с количеством полученных монеток
    /// </summary>
    public class RewardScreen : BaseScreenWithContext<RewardContext>
    {
        [SerializeField]
        private Text _goldCountLabel;
        [SerializeField]
        private Button _okButton;
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
        public void OnClick()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
        public override void ApplyContext(RewardContext context)
        {
            _goldCountLabel.text = context.Gold.ToString();
        }
    }
}
