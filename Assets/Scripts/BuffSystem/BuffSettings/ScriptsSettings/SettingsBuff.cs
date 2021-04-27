using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    public abstract class SettingsBuff : ScriptableObject
    {
        public abstract IBuff CreateBuff();
    }
}
