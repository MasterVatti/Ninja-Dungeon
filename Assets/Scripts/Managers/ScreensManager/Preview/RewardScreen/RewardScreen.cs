using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager.Preview.RewardScreen
{
    /// <summary>
    /// Пример окна.
    /// В данном случае тестовое окно с количеством полученных монеток
    /// </summary>
    public class RewardScreen : BaseScreen
    {
        [SerializeField]
        private Text _goldCountLabel;

        public override void Initialize<TRewardScreenContext>(ScreenType type,
            TRewardScreenContext screenContext)
        {
            ScreenType = type;

            if (screenContext is RewardScreenContext rewardScreenContext)
            {
                _goldCountLabel.text = rewardScreenContext.Gold.ToString();
            }
            else
            {
                throw new Exception("Invalid context " +
                                    "for a specific window was received. " +
                                    "Check the context you passed in.");
            }
        }
    }
}
