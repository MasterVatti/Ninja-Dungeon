using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/FrontalProjectileBuff", order = 7)]
    public class FrontalProjectileBuffSettings : SettingsBuff
    {
        public override IBuff CreateBuff()
        {
            return new FrontalProjectileBuff((PlayerCharacteristics)PersonCharacteristics);
        }
    }
}
