using ResourceSystem;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Класс отвечает за получение подобранного ресурса
    /// </summary>
    public class ResourceItemLoot : EquipmentItemLoot
    {
        [SerializeField]
        private int _experienceСount;
        
        private ResourceType _resourceType;
        private float _amount;

        public override void Initialize(ItemLoot itemLoot)
        {
            if (itemLoot is ResourceItem resourceItem)
            {
                _resourceType = resourceItem.Resource.Type;
                _amount = resourceItem.Resource.Amount;
            }
        }

        protected override void OnItemPickup()
        {
            MainManager.Player.ExperienceControllerDungeon.AddExperience(_experienceСount);
            DungeonManager.RewardManager.AddReward(_resourceType, (int) _amount);
        }
    }
}
