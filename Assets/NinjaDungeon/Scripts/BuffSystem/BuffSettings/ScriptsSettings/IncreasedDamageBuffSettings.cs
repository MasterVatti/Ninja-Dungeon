using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/BuffIncreasedDamage", order = 1)]
    public class IncreasedDamageBuffSettings : SettingsBuff
    {
        [Header("Damage increase by %")]
        [Range(0, 100)]
        [SerializeField]
        private int _percentageIncrease;
        
        public override IBuff CreateBuff(PersonCharacteristics personCharacteristics)
        {
            return new IncreasedDamageBuff(_percentageIncrease, personCharacteristics);
        }
    }
}
