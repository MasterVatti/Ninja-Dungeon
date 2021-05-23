using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using BuffSystem.BuffSettings.ScriptsSettings;
using Characteristics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BuffSystem
{
    /// <summary>
    /// Класс служит для распределения кнопкам рандомные баффы
    /// </summary>
    public class SelectBuffScreen : BaseScreen
    {
        [SerializeField]
        private List<BuffButton> _buffButtons = new List<BuffButton>();
        [SerializeField]
        private List<SettingsBuff> _settingsBuffs = new List<SettingsBuff>();
        
        private void Awake()
        {
            var player = MainManager.Player;
            var buffManager = player.BuffManager;
            var personCharacteristics = player.GetComponent<PersonCharacteristics>();
            
            foreach (var buffbutton in _buffButtons)
            {
                buffbutton.Initialize(personCharacteristics, buffManager, GetRandomSettingBuffs());
            }
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
        
    }
}
