﻿using Assets.Scripts.Managers.ScreensManager;
using HUD;
using UnityEngine;

namespace NinjaDungeon.Scripts.BattleManager
{
    public class RewardScreen : BaseScreenWithContext<RewardScreenContext>
    {
        [SerializeField]
        private Transform _transformCreateRewardLabel;
        [SerializeField]
        private ResourceRewardLabel _prefabRewardLabel;
        
        public override void ApplyContext(RewardScreenContext context)
        {
            foreach (var rewardedResource in context.RewardedResources)
            {
                var rewardLabel = Instantiate(_prefabRewardLabel, _transformCreateRewardLabel);

                var sprite = MainManager.IconsProvider.GetResourceSprite(rewardedResource.Type);
                rewardLabel.Initialize(sprite, rewardedResource.Amount);
            }
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}