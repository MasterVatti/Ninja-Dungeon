using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/RicochetShellsBuff", order = 5)]
    public class RicochetShellsBuffSettings : SettingsBuff
    {
        [SerializeField]
        private int _ricochetsNumber;
        
        public override IBuff CreateBuff(PersonCharacteristics personCharacteristics)
        {
            return new RicochetShellsBuff(_ricochetsNumber, (PlayerCharacteristics)personCharacteristics);
        }
    }
}
