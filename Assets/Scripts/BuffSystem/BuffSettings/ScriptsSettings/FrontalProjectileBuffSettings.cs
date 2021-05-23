using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/FrontalProjectileBuff", order = 7)]
    public class FrontalProjectileBuffSettings : SettingsBuff
    {
        [SerializeField] 
        private bool _hasFrontalProjectile;
        
        public override IBuff CreateBuff(PersonCharacteristics personCharacteristics)
        {
            return new FrontalProjectileBuff((PlayerCharacteristics)personCharacteristics, _hasFrontalProjectile);
        }
    }
}
