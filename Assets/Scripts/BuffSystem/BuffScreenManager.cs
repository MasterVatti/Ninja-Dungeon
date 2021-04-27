using System.Collections.Generic;
using BuffSystem.BuffInterface;
using BuffSystem.BuffSettings.ScriptsSettings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BuffSystem
{
    public class BuffScreenManager : MonoBehaviour
    {
        [SerializeField]
        private List<BuffButton> _buffButtons = new List<BuffButton>();
        [SerializeField]
        private List<SettingsBuff> _settingsBuffs = new List<SettingsBuff>();
        
        private void Awake()
        {
            foreach (var buffbutton in _buffButtons)
            {
                buffbutton.OnClicked += ClickedBuff;
                
                buffbutton.Initialize(GetRandomSettingBuffs());
            }
        }

        private void ClickedBuff(IBuff buff)
        {
            MainManager.BuffManager.AddBuff(buff);
        }
        
        private SettingsBuff GetRandomSettingBuffs()
        {
            var randomValue = Random.Range(0, _settingsBuffs.Count);
            
            return _settingsBuffs[randomValue];
        }

        private void OnDestroy()
        {
            foreach (var buffbutton in _buffButtons)
            {
                buffbutton.OnClicked -= ClickedBuff;
            }
        }
    }
}
