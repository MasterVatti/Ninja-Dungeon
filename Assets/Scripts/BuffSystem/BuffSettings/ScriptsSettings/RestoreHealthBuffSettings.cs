using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/InstantBuff/BuffHealthBoost", order = 2)]
    public class RestoreHealthBuffSettings : SettingsBuff
    {
        [Header("Health increase by %")]
        [Range(0, 100)]
        [SerializeField]
        private int _percentageIncrease;
        
        public override IBuff CreateBuff(PersonCharacteristics personCharacteristics)
        {
            return new RestoreHealthBuff(_percentageIncrease, personCharacteristics);
        }
    }
}
