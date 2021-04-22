using ResourceSystem;

namespace Loot
{
    /// <summary>
    /// Класс отвечает за получение подобранного ресурса
    /// </summary>
    public class ResourceItemLoot : EquipmentItemLoot
    {
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
            MainManager.ResourceManager.AddResource(_resourceType, (int) _amount);
        }
    }
}
