using Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Находит ближайшего врага и атакует его
    /// </summary>
    [RequireComponent(typeof(IAttackBehaviour))]
    public class ProjectileLauncher : MonoBehaviour
    {
        private IAttackBehaviour _attackBehaviour;
        private NearestTargetProvider _nearestTargetProvider;

        private void Awake()
        {
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _nearestTargetProvider = new NearestTargetProvider();
        }

        private void Update()
        {
            if (_attackBehaviour.IsCooldown && MainManager.EnemiesManager.Enemies.Count >= 0)
            {
                return;
            }
            
            var enemy = _nearestTargetProvider.GetNearestTarget(MainManager.EnemiesManager.Enemies, transform.position);
            if (_attackBehaviour.CanAttack(enemy))
            {
                transform.parent.LookAt(enemy.transform);
                _attackBehaviour.Attack(enemy);
            }
        }
    }
}