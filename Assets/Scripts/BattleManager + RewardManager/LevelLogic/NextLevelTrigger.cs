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
        
        private void OnTriggerEnter(Collider nextLevelCollider)
        {
            if (MainManager.EnemiesManager.Enemies.Count == 0 
                && nextLevelCollider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                MainManager.BattleManager.GoToNextLevel(_settings.RoomSettings, _settings.TeleportPosition);
            }
        }
        
    }
}
