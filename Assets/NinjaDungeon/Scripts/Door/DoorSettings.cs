using System;
using Assets.Scripts.BattleManager;
using UnityEngine;

namespace Door
{
    /// <summary>
    /// Класс отвечает за настройки дверей(куда отправится и описание)
    /// </summary>
    [Serializable]
    public class DoorSettings
    {
        public RoomSettings RoomSettings => _roomSettings;
        public Vector3 TeleportPosition => _teleportPosition;

        [SerializeField]
        private RoomSettings _roomSettings;
        [SerializeField]
        private Vector3 _teleportPosition;
    }
}