using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/InstantBuff/BuffHealthBoost", order = 0)]
    public class RestoreHealthBuffSettings : SettingsBuff
    {
        [Header("Health increase by %")]
        [Range(0, 100)]
        [SerializeField]
        private int _percentageIncrease;
        
        public override IBuff CreateBuff()
        {
            return new RestoreHealthBuff(_percentageIncrease);
        }
    }
}
