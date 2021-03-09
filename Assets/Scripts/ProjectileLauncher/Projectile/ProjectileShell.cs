using Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public class ProjectileShell : MonoBehaviour
    {
        public static ProjectileShell Singleton { get; private set; }
        [SerializeField] 
        private float _bulletSpeed;
        [SerializeField] 
        private int _damage;
        [SerializeField] 
        private ProjectileLauncher _projectileLauncher;

        private Vector3 _nearestEnemyPosition;
        private Transform _startPosition;
        public int Damage => _damage;

        private void Awake()
        {
            _nearestEnemyPosition = _projectileLauncher.NearestEnemyCoordinates;
            _startPosition = transform;
            Singleton = this;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(_startPosition.position,
                _nearestEnemyPosition, Time.deltaTime * _bulletSpeed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _projectileLauncher.OnProjectileDestroy(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
