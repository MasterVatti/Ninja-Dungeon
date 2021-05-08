using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Контекст дверей подземелья
    /// </summary>
    public class DungeonDoorContext : BaseContext
    {
        public RoomSettings RoomSettings
        {
            get { return _roomSettings; }
            set { _roomSettings = value; }
        }
        public Vector3 TeleportPosition
        {
            get { return _teleportPosition; }
            set { _teleportPosition = value; }
        }

        [SerializeField]
        private RoomSettings _roomSettings;
        [SerializeField]
        private Vector3 _teleportPosition;
    }
}