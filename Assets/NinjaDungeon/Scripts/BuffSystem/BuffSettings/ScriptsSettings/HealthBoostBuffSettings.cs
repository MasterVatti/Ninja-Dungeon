using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/BuffHealthBoost", order = 0)]
    public class HealthBoostBuffSettings : SettingsBuff
    {
        [Header("Max HP increase by %")]
        [Range(0, 100)]
        [SerializeField]
        private int _percentageIncrease;
        
        public override IBuff CreateBuff(PersonCharacteristics personCharacteristics)
        {
            return new HealthBoostBuff(_percentageIncrease, personCharacteristics);
        }
    }
}
