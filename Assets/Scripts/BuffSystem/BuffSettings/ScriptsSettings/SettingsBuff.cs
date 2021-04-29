using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    /// <summary>
    /// Базовые настройки для бафов
    /// </summary>
    public abstract class SettingsBuff : ScriptableObject
    {
        public BuffType BuffType => _buffType;
        public string NameBuff => _nameBuff;
        public Sprite ImageBuff => _imageBuff;
        
        [SerializeField]
        private string _nameBuff;
        [SerializeField]
        private Sprite _imageBuff;
        [SerializeField]
        private BuffType _buffType;
        
        public abstract IBuff CreateBuff();
    }
}
