using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/ProjectileBackBuff", order = 8)]
    public class ProjectileBackSettings : SettingsBuff
    {
        [SerializeField]
        private bool _hasProjectileBack;
        
        public override IBuff CreateBuff()
        {
            return new ProjectileBackBuff((PlayerCharacteristics)PersonCharacteristics, _hasProjectileBack);
        }
    }
}
