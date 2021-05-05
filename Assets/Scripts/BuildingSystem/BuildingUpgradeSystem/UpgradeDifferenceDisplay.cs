using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeDifferenceDisplay : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _differenceLayoutGroup;

        private ObjectPool _labelPool;

        public void Initialize(ObjectPool labelPool)
        {
            _labelPool = labelPool;
        }
        
        public void ShowUpgradeDifference(IReadOnlyDictionary<string, int> oldStateDictionary, 
        IReadOnlyDictionary<string, int> newStateDictionary)
        {
            var upgradeDifference = GetUpgradeDifference(oldStateDictionary, newStateDictionary);

            foreach (var pair in upgradeDifference)
            {
                var keyLabel = _labelPool.Get();
                UpgradeLabelHandler.SetLabelText(keyLabel, pair.Key);
                keyLabel.transform.SetParent(_differenceLayoutGroup, false);
                
                var newValueLabel = _labelPool.Get();
                UpgradeLabelHandler.SetLabelText(newValueLabel, newStateDictionary[pair.Key].ToString());
                newValueLabel.transform.SetParent(_differenceLayoutGroup, false);

                var newValueDifferenceLabel = _labelPool.Get();
                UpgradeLabelHandler.SetLabelText(newValueDifferenceLabel, "(+" + upgradeDifference[pair.Key]+")");
                newValueDifferenceLabel.transform.SetParent(_differenceLayoutGroup, false);
            }
        }
        
        private static Dictionary<string, int> GetUpgradeDifference(IReadOnlyDictionary<string, int> oldStateDictionary, 
        IReadOnlyDictionary<string, int> newStateDictionary)
        {
            var result = oldStateDictionary.ToDictionary(pair => pair.Key, 
            pair => newStateDictionary[pair.Key] - oldStateDictionary[pair.Key]);
            
            return result;
        }
    }
}
