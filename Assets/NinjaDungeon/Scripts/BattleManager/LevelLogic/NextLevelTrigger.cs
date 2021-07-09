using Door;
using Enemies.Spawner;
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
        
        private void OnTriggerEnter(Collider nextLevelCollider)
        {
            var hasLevelPassed = DungeonManager.BattleManager.HasLevelPassed;
            
            if (hasLevelPassed && nextLevelCollider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                DungeonManager.BattleManager.GoToNextLevel(_settings.RoomSettings, _settings.TeleportPosition);
            }
        }
    }
}
