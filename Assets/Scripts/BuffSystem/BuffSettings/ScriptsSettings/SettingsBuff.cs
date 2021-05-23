using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    /// <summary>
    /// Базовые настройки для бафов
    /// </summary>
    public abstract class SettingsBuff : ScriptableObject
    {
        public string NameBuff => _nameBuff;
        public Sprite ImageBuff => _imageBuff;
        
        [SerializeField]
        private string _nameBuff;
        [SerializeField]
        private Sprite _imageBuff;
        
        public abstract IBuff CreateBuff(PersonCharacteristics personCharacteristics);
    }
}
