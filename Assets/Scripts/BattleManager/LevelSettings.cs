using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    [Serializable]
    public class LevelSettings
    {
        public string SceneName => _sceneName;
        public List<Resource> Rewards => _rewards;
        
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private List<Resource> _rewards = new List<Resource>();
    }
}