using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    [CreateAssetMenu(fileName = "DungeonSettings", menuName = "ScriptableObjects/DungeonSettings", order = 1)]
    public class DungeonSettings : ScriptableObject
    {
        public List<RoomSettings> RoomSettings => _roomSettingsList;
        
        [SerializeField]
        private List<RoomSettings> _roomSettingsList = new List<RoomSettings>();
    } 
}