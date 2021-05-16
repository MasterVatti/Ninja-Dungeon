using System.Collections.Generic;
using Characteristics;
using ResourceSystem;
using UnityEngine;

namespace Buildings.PlayerCharacteristicsImprove
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacteristicImproveSettings", order = 0)]
    public class CharacteristicImproveSettings : ScriptableObject
    {
        public List<Resource> Cost
        {
            get
            {
                var playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
                var characteristicLevel = playerCharacteristics.GetCharacteristic(CharacteristicType).Level;

                var newCost = new List<Resource>();

                foreach (var resource in _baseCost)
                {
                    var res = resource;
                    var multiplier = characteristicLevel == 0 ? 0.5f : Mathf.Pow(characteristicLevel, 2); 
                    
                    res.Amount = resource.Amount * multiplier;
                    
                    newCost.Add(res);
                }

                return newCost;
            }
        }
        public List<Resource> VariantCost => _variantCost;
        public CharacteristicType CharacteristicType => _characteristicType;

        [SerializeField]
        private List<Resource> _baseCost;
        [SerializeField]
        private List<Resource> _variantCost;
        [SerializeField]
        private CharacteristicType _characteristicType;
    }
}
