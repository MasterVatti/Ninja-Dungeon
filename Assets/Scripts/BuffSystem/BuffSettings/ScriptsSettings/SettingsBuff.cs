using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    public abstract class SettingsBuff : ScriptableObject
    {
        public BuffType BuffType => _buffType;

        [SerializeField]
        private BuffType _buffType;
        public abstract IBuff CreateBuff();
    }
}
