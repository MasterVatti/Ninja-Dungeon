using System;
using BuffSystem.BuffInterface;
using BuffSystem.BuffSettings.ScriptsSettings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuffSystem
{
    public class BuffButton : MonoBehaviour
    {
        public event Action<IBuff, BuffType> OnClicked;

        public BuffType BuffType => _settingsBuff.BuffType;
            
        [SerializeField]
        private Image _imageBuff;
        [SerializeField]
        private TextMeshProUGUI _textBuff;
        
        private SettingsBuff _settingsBuff;
        
        public void Initialize(SettingsBuff settingsBuff)
        {
            _settingsBuff = settingsBuff;

            _imageBuff.sprite = settingsBuff.ImageBuff;
            _textBuff.text = settingsBuff.NameBuff;

        }
        
        public void OnClick()
        {
            OnClicked?.Invoke(_settingsBuff.CreateBuff(), BuffType);
        }
    }
}
