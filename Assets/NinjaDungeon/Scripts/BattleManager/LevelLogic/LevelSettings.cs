using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Класс отвечает за настройки уровня (имя сцены, награда, бонус)
    /// </summary>
    [Serializable]
    public class  LevelSettings
    {
        public string SceneName => _sceneName;
        public int UpperWorldExperienceAward => _upperWorldExperienceAward;
        public List<Resource> DefaultReward => _defaultReward;
        public List<Resource> BonusReward => _bonusReward;
        
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private int _upperWorldExperienceAward;
        [SerializeField]
        private List<Resource> _defaultReward = new List<Resource>();
        [SerializeField]
        private List<Resource> _bonusReward = new List<Resource>();

    }
}