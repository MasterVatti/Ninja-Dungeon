using System;
using Assets.Scripts.Managers.ScreensManager;
using Door;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Класс отвечает за переход на следующий уровень
    /// </summary>
    public class NextLevelTrigger : MonoBehaviour
    {
        [SerializeField]
        private DoorSettings _settings;
        private RoomSettings _roomSettings;

        private void OnTriggerEnter(Collider nextLevelCollider)
        {
            var context = new DungeonDoorContext()
            {
                RoomSettings = _settings.RoomSettings,
                TeleportPosition = _settings.TeleportPosition
            };
            
            if (MainManager.EnemiesManager.Enemies.Count == 0 &&
                nextLevelCollider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                BattleManager.Instance.GoToNextLevel(context, context);
            }
        }
        
    }
}
