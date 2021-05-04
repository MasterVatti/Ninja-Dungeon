using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/SideShellsBuff", order = 9)]
    public class SideShellsSettings : SettingsBuff
    {
        [SerializeField]
        private bool _hasSideShells;
        
        public override IBuff CreateBuff()
        {
            return new SideShellsBuff((PlayerCharacteristics)PersonCharacteristics, _hasSideShells);
        }
    }
}
