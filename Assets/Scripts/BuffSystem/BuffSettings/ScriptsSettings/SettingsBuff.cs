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
        public PersonCharacteristics PersonCharacteristics
        {
            get => _personCharacteristics;
            set => _personCharacteristics = value;
        }
        
        public string NameBuff => _nameBuff;
        public Sprite ImageBuff => _imageBuff;
        
        [SerializeField]
        private string _nameBuff;
        [SerializeField]
        private Sprite _imageBuff;

        private PersonCharacteristics _personCharacteristics;
        public abstract IBuff CreateBuff();
    }
}
