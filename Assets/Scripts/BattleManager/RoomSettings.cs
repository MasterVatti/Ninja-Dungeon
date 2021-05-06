using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    [CreateAssetMenu(fileName = "RoomSettings", menuName = "ScriptableObjects/RoomSettings", order = 1)]
    public class RoomSettings : ScriptableObject
    {
        public List<LevelSettings> LevelSettingsList => _levelSettingsList;
        
        [SerializeField]
        private List<LevelSettings> _levelSettingsList = new List<LevelSettings>();
    }
}