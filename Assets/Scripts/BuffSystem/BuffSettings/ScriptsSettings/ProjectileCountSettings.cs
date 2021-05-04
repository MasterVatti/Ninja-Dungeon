using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/ProjectileCountBuff", order = 4)]
    public class ProjectileCountSettings : SettingsBuff
    {
        [SerializeField]
        private int _projectileCount;
        
        public override IBuff CreateBuff()
        {
            return new ProjectileCountBuff(_projectileCount, (PlayerCharacteristics)PersonCharacteristics);
        }
    }
}
