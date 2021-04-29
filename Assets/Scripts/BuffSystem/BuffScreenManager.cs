using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using BuffSystem.BuffInterface;
using BuffSystem.BuffSettings.ScriptsSettings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BuffSystem
{
    /// <summary>
    /// Класс служит для распределения кнопкам рандомные баффы
    /// </summary>
    public class BuffScreenManager : BaseScreen
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

        private void ClickedBuff(IBuff buff, BuffType buffType)
        {
            MainManager.BuffManager.AddBuff(buff, buffType);
            
            MainManager.ScreenManager.CloseTopScreen();
        }
        
        private SettingsBuff GetRandomSettingBuffs()
        {
            var randomValue = Random.Range(0, _settingsBuffs.Count);
            
            return _settingsBuffs[randomValue];
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
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
