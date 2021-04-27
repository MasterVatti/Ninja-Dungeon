using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/BuffHealthBoost", order = 2)]
    public class HealthBoostSettings : SettingsBuff
    {
        [SerializeField]
        private int _amountIncreasedHealth;

        public override IBuff CreateBuff()
        {
            return new HealthBoostBuff(_amountIncreasedHealth);
        }
    }
}
