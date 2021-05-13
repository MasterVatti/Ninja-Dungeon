using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Класс отвечает за настройки уровня (имя сцены, награда)
    /// </summary>
    [Serializable]
    public class LevelSettings
    {
        public string SceneName => _sceneName;
        public List<Resource> DefaultReward => _defaultReward;
        public List<Resource> BonusReward => _bonusReward;
        
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private List<Resource> _defaultReward = new List<Resource>();
        [SerializeField]
        private List<Resource> _bonusReward = new List<Resource>();

    }
}