using ObjectPools;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeCostDisplay : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _costLayoutGroup;
        [SerializeField]
        private ResourceView _resourceView;

        private MonoBehaviourPool<ResourceView> _resourceViewPool;

        private void Awake()
        {
            _resourceViewPool = new MonoBehaviourPool<ResourceView>(_resourceView, _costLayoutGroup);
        }

        public void ShowUpgradeCost(BuildingUpgrade buildingUpgrade)
        {
            _resourceViewPool.ReleaseAll();
            foreach (var resource in buildingUpgrade.UpgradeCost)
            {
                var resourceView = _resourceViewPool.Take();
                resourceView.Initialize(resource.Type, resource.Amount);
            }
        }
    }
}
