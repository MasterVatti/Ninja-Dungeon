using System.Collections.Generic;
using System.Linq;
using ObjectPools;
using TMPro;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeDifferenceDisplay : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _differenceLayoutGroup;
        [SerializeField]
        private TextMeshProUGUI _labelPrefab;
        
        public void ShowUpgradeDifference(IReadOnlyDictionary<string, int> oldStateDictionary, 
        IReadOnlyDictionary<string, int> newStateDictionary)
        {
            var upgradeDifference = GetUpgradeDifference(oldStateDictionary, newStateDictionary);
            var labelPool = new MonoBehaviourPool<TextMeshProUGUI>(_labelPrefab, _differenceLayoutGroup);
            
            foreach (var pair in upgradeDifference)
            {
                var keyLabel = labelPool.Take();
                keyLabel.text = pair.Key;
                
                var newValueLabel = labelPool.Take();
                newValueLabel.text = newStateDictionary[pair.Key].ToString();

                var newValueDifferenceLabel = labelPool.Take();
                newValueDifferenceLabel.text = "(+" + upgradeDifference[pair.Key] + ")";
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
