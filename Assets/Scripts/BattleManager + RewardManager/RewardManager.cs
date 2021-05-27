using System.Collections.Generic;
using ResourceSystem;

namespace Assets.Scripts.BattleManager
{
    public class RewardManager
    {
        private Dictionary<ResourceType, List<int>> _rewardDictionary = new Dictionary<ResourceType, List<int>>();
        private Dictionary<ResourceType, List<int>> _bonusDictionary = new Dictionary<ResourceType, List<int>>();

        public void LevelRewardAccrual(RoomSettings roomSettings, int currentLevelIndex)
        {
            var nextLevel = roomSettings.LevelSettingsList;

            var rewardList = nextLevel[currentLevelIndex].DefaultReward;
            GetLevelReward(_rewardDictionary, rewardList);

            rewardList = nextLevel[currentLevelIndex].BonusReward;
            GetLevelReward(_rewardDictionary, rewardList);
        }

        private void GetLevelReward(Dictionary<ResourceType, List<int>> rewardDictionary, List<Resource> rewardList)
        {
            foreach (var reward in rewardList)
            {
                if (rewardDictionary.TryGetValue(reward.Type, out var amountList))
                {
                    amountList.Add(reward.Amount);
                }
                else
                {
                    amountList = new List<int>
                    {
                        reward.Amount
                    };

                    rewardDictionary.Add(reward.Type, amountList);
                }
            }
        }

        public void GetFinalReward()
        {
            foreach (var reward in _rewardDictionary)
            {
                EarnReward(reward.Key, reward.Value);
            }

            foreach (var bonus in _bonusDictionary)
            {
                EarnReward(bonus.Key, bonus.Value);
            }

            _rewardDictionary.Clear();
            _bonusDictionary.Clear();
        }

        private void EarnReward(ResourceType type, List<int> amount)
        {
            foreach (var reward in amount)
            {
                MainManager.ResourceManager.AddResource(type, reward); //<-- Награда за все уровни
            }
        }
    }
}