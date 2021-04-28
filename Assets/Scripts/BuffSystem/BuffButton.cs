using System;
using BuffSystem.BuffInterface;
using BuffSystem.BuffSettings.ScriptsSettings;
using UnityEngine;

namespace BuffSystem
{
    public class BuffButton : MonoBehaviour
    {
        public event Action<IBuff, BuffType> OnClicked;

        public BuffType BuffType => _settingsBuff.BuffType;
            
        private SettingsBuff _settingsBuff;
        
        public void Initialize(SettingsBuff settingsBuff)
        {
            _settingsBuff = settingsBuff;
            
        }
        
        public void OnClick()
        {
            OnClicked?.Invoke(_settingsBuff.CreateBuff(), BuffType);
        }
    }
}
