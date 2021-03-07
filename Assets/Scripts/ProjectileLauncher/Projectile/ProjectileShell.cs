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
        private NearestEnemyDetector _enemyDetector;
        [SerializeField] 
        private int _damage;
        [SerializeField] 
        private ProjectileLauncher _projectileLauncher;

        private Vector3 _nearestEnemyPosition;
        private Transform _startPosition;
        public int Damage => _damage;

        private void Awake()
        {
            _nearestEnemyPosition = _enemyDetector.NearestEnemyCoords;
            _startPosition = transform;
            Singleton = this;
        }

        private void Update()
        {
            if (gameObject)
            {
                transform.position = Vector3.Lerp(_startPosition.position,
                    _nearestEnemyPosition, Time.deltaTime * _bulletSpeed);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                var shells = _projectileLauncher.shells;
                for (int i = 0; i < shells.Count; i++)
                {
                    if (shells[i] == gameObject)
                    {
                        _projectileLauncher.shells.RemoveAt(i);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
