using Enemies;
using Panda;
using UnityEngine;

namespace Magician
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) мага (пока спавн голема и отбегание).
    /// </summary>
    public class MagicianAI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _golemPrefab;
        [SerializeField]
        private Unit _unit;
        [SerializeField]
        private float _runBackDistance;
        [SerializeField]
        private EnemyHealth _enemyHealth;
        [SerializeField]
        private float _lowHealthThreshold;
    
        private bool _isGolemCreated;
    
        [Task]
        private bool GolemSpawn()
        {
            if (!_isGolemCreated)
            {
                var golem = Instantiate(_golemPrefab, gameObject.transform.position, Quaternion.identity);
                _isGolemCreated = true;
            }

            return false;
        }
    
        [Task]
        private void GetRunBackPoint()
        {
            _unit.ChangePointMovement(gameObject.transform.TransformPoint(0, 0, 0 - _runBackDistance));
            Task.current.Succeed();
        }
        
        [Task]
        private bool IsHealthEnoughToSpawnGolem()
        {
            return _enemyHealth.CurrentHealth <= _lowHealthThreshold;
        }
    }
}
