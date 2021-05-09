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

        private MonoBehaviourPool<TextMeshProUGUI> _labelPool;

        private void Awake()
        {
            _labelPool = new MonoBehaviourPool<TextMeshProUGUI>(_labelPrefab, _differenceLayoutGroup);
        }

        public void ShowUpgradeDifference(IReadOnlyDictionary<string, int> oldStateDictionary, 
        IReadOnlyDictionary<string, int> newStateDictionary)
        {
            var upgradeDifference = GetUpgradeDifference(oldStateDictionary, newStateDictionary);
            _labelPool.ReleaseAll();
            
            foreach (var pair in upgradeDifference)
            {
                var characteristicName = pair.Key;
                var newCharacteristicValue = newStateDictionary[characteristicName]; 
                var differenceValue = upgradeDifference[characteristicName];

                //лейблы распологаются в GridLayoutGroup
                //результат: Скорость добычи 50 (+10)
                _labelPool.Take().text = characteristicName;
                _labelPool.Take().text = newCharacteristicValue.ToString();
                var differentLabel = _labelPool.Take();
                differentLabel.text = "(+" + differenceValue + ")";
                differentLabel.color = Color.green;
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
