using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/BuffIncreasedAttackSpeed", order = 3)]
    public class IncreasedAttackRateSettings : SettingsBuff
    {
        [Header("Attack rate increase by %")]
        [Range(0, 100)]
        [SerializeField]
        private int _percentageIncrease;
        public override IBuff CreateBuff()
        {
            return new AttackRateBuff(_percentageIncrease);
        }
    }
}
