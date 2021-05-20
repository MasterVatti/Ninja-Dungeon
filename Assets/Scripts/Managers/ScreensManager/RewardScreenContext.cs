using System.Collections.Generic;
using Loot;
using ResourceSystem;

namespace Assets.Scripts.Managers.ScreensManager
{
    public class RewardScreenContext : BaseContext
    {
        public List<Resource> RewardedResources { get; }

        public RewardScreenContext(List<Resource> rewardedResources)
        {
            RewardedResources = rewardedResources;
        }
    }
}