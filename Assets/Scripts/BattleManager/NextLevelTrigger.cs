using System;
using Enemies;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    public class NextLevelTrigger : MonoBehaviour
    {
        private LevelSettings _levelSettings;

        private void OnTriggerEnter(Collider nextLevelCollider)
        {
            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy == null & nextLevelCollider.CompareTag(GlobalConstants.PLAYER_TAG))
                {
                    _levelSettings.SceneIndex++;
                    //начислить базовую награду за уровень (без UI)
                    //телепорт на некст левел
                }
            }
        }
    }
}