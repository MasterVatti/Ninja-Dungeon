using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreensManager.Preview.RewardScreen
{
    /// <summary>
    /// Пример окна.
    /// В данном случае тестовое окно с количеством полученных монеток
    /// </summary>
    public class RewardScreen : BaseScreenWithContext
    {
        [SerializeField]
        private Text _goldCountLabel;

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        public override void ApplyContext<TContext>(TContext context)
        {
            if (context is RewardContext rewardScreenContext)
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
