using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/MultishotBuff", order = 4)]
    public class MultishotBuffSettings : SettingsBuff
    {
        [SerializeField]
        private int _multishotsNumber;
        
        public override IBuff CreateBuff()
        {
            return new MultishotBuff(_multishotsNumber);
        }
    }
}
