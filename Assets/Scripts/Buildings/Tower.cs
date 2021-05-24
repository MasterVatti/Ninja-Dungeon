using BuildingSystem;
using Enemies;
using SaveSystem;
using UnityEngine;

namespace Buildings
{
    public class Tower : Building<TowerData>
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _attackCooldown;
        [SerializeField]
        private float _attackRange;
        [SerializeField]
        private ProjectileLauncher.ProjectileLauncher _launcher;
        
        private NearestEnemyDetector _detector;

        private void Awake()
        {
            var go = gameObject;
            _detector = go.AddComponent<NearestEnemyDetector>();
            _detector.AttackerTransform = go.transform;
            
            _launcher.EnemyDetector = _detector;
            _launcher.ProjectileSpawnCooldown = _attackCooldown;
            
            _launcher.Projectile.Damage = _damage;
        }

        public override TowerData GetState()
        {
            return new TowerData
            {
                Damage = _damage,
                AttackCooldown = _attackCooldown,
                AttackRange = _attackRange
            };
        }

        protected override void OnStateLoaded(TowerData data)
        {
            _damage = data.Damage;
            _attackRange = data.AttackRange;
            _attackCooldown = data.AttackCooldown;
        }
    }
}
