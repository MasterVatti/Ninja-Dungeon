using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    public class RewardManager : MonoBehaviour
    {
        public event Action<Resource,int> OnResourceAmountChanged; 
        
        private const int MIN_INDEX_RESOURCE = 0;

        private List<Resource> _reward;

        private void Start()
        {
            _reward = new List<Resource>();
        }

        public void LevelRewardAccrual(RoomSettings roomSettings, int currentLevelIndex)
        {
            var nextLevel = roomSettings.LevelSettingsList;

            var rewardList = nextLevel[currentLevelIndex].DefaultReward;
            AddReward(rewardList);
            rewardList = nextLevel[currentLevelIndex].BonusReward;
            AddReward(rewardList);
        }
        
        public void AddReward(ResourceType type, int value)
        {
            var index = GetResourceIndexByType(type);
            var resource = _reward[index];
            resource.Amount += value;
            OnResourceAmountChanged?.Invoke(resource, resource.Amount);
            _reward[index] = resource;
        }
        
        private void AddReward(IEnumerable<Resource> resources)
        {
            foreach (var resource in resources)
            {
                AddReward(resource.Type, resource.Amount);
            }
        }
        
        private int GetResourceIndexByType(ResourceType type)
        {
            var index = _reward.FindIndex(resource => resource.Type == type);

            if (index < MIN_INDEX_RESOURCE)
            {
                AddResourceType(type);
                index = GetResourceIndexByType(type);
            }
            
            return index;
        }

        private void AddResourceType(ResourceType type)
        {
            _reward.Add(new Resource { Amount = 0, Type = type });
        }
        
        public List<Resource> GetResources()
        {
            return _reward;
        }
        
        public void AccrueReward()
        {
            MainManager.ResourceManager.AddResource(_reward);
        }
    }
}