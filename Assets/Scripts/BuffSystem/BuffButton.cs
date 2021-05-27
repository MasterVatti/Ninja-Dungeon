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
        private BuffManager _buffManager;

        public void Initialize(PersonCharacteristics personCharacteristics, BuffManager buffManager, 
            SettingsBuff settingsBuff)
        {
            _buffManager = buffManager;
            _settingsBuff = settingsBuff;

            _personCharacteristics = personCharacteristics;
            _imageBuff.sprite = settingsBuff.ImageBuff;
            _textBuff.text = settingsBuff.NameBuff;
        }
        
        public void OnClick()
        {
            _buffManager.AddBuff(_settingsBuff.CreateBuff(_personCharacteristics));
            
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}
