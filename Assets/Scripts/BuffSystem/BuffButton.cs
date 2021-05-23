using System;
using BuffSystem.BuffInterface;
using BuffSystem.BuffSettings.ScriptsSettings;
using Characteristics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuffSystem
{
    /// <summary>
    /// Кнопка способностей служит для передачи выбранного баффа
    /// </summary>
    public class BuffButton : MonoBehaviour
    {
        [SerializeField]
        private Image _imageBuff;
        [SerializeField]
        private TextMeshProUGUI _textBuff;
        
        private SettingsBuff _settingsBuff;
        private PersonCharacteristics _personCharacteristics;
        
        public void Initialize(PersonCharacteristics personCharacteristics, SettingsBuff settingsBuff)
        {
            _settingsBuff = settingsBuff;

            _personCharacteristics = personCharacteristics;
            _imageBuff.sprite = settingsBuff.ImageBuff;
            _textBuff.text = settingsBuff.NameBuff;
        }
        
        public void OnClick()
        {
            MainManager.BuffManager.AddBuff(_settingsBuff.CreateBuff(_personCharacteristics));
            
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}
