using System.Collections.Generic;
using Loot;
using ResourceSystem;

namespace Assets.Scripts.Managers.ScreensManager
{
    public class RewardScreenContext : BaseContext
    {
        public List<Resource> RewardedResources { get; }
        public int ExperienceReward { get; }

        public RewardScreenContext(List<Resource> rewardedResources, int experienceReward)
        {
            RewardedResources = rewardedResources;
            ExperienceReward = experienceReward;
        }
    }
}