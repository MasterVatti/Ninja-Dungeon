namespace HUD
{
    public class ResourceViewDungeon : ResourceView
    {
        protected override void Start()
        {
            _resources = DungeonManager.RewardManager.GetResources();
            base.Start();
            DungeonManager.RewardManager.OnResourceAmountChanged += OnResourceAmountChanged;
        }
    
        private void OnDestroy()
        {
            DungeonManager.RewardManager.OnResourceAmountChanged -= OnResourceAmountChanged;
        }
    }
}