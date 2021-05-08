using System;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    public class NextLevelTrigger : MonoBehaviour
    {
        private RoomSettings _roomSettings;
        private void OnTriggerEnter(Collider nextLevelCollider)
        {
            if (IsNextLevelAccessed(nextLevelCollider))
            {
                BattleManager.Instance.GoToNextLevel(_roomSettings);
            }
        }

        private bool IsNextLevelAccessed(Collider nextLevelCollider)
        {
            if (MainManager.EnemiesManager.Enemies.Count == 0 &&
                nextLevelCollider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                return true;
            }
            return false;
        }
    }
}