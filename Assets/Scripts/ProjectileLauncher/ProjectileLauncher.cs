using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Находит ближайшего врага и атакует его
    /// </summary>
    [RequireComponent(typeof(IEnemyDetector))]
    [RequireComponent(typeof(IAttackMechanic))]
    public class ProjectileLauncher : MonoBehaviour
    {
        private IAttackMechanic _attackMechanic;
        private IEnemyDetector _enemyDetector;

        private void Awake()
        {
            _enemyDetector = GetComponent<IEnemyDetector>();
            _attackMechanic = GetComponent<IAttackMechanic>();
        }

        private void Update()
        {
            if (_attackMechanic.IsCooldown || !_attackMechanic.CanShoot)
            {
                return;
            }
            
            var enemy = _enemyDetector.GetEnemy();
            if (enemy != null)
            {
                // TODO : should be fixed in Max's branch
                //transform.parent.LookAt(enemy.transform);
                
                var enemyDirection = (enemy.transform.position - transform.position).normalized;
                _attackMechanic.Shoot(enemyDirection);
            }
        }
    }
}