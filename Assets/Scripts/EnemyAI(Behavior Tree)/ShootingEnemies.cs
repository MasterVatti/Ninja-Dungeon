using Assets.Scripts;
using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за дальние атаки врагов
/// </summary>
public class ShootingEnemies : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shotCooldownTime;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Unit _unit;

    private GameObject _target;
    private float _nextShotTime;


    private void Shot()
    {
        _agent.isStopped = true;
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            gameObject.transform.LookAt(_unit.Target.transform.position);


            CreateBullet();
        }
    }

    private void CreateBullet()
        {
            var newBullet = Instantiate(_bulletPrefab, transform.position,
                transform.rotation);

            newBullet.velocity = transform.forward * _bulletSpeed;
        }

        [Task]
        private void Shooting()
        {
            var directionToPlayer = _unit.Target.transform.position - transform.position;

            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out var hit))
            {
                if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG) ||
                    hit.collider.CompareTag(GlobalConstants.ALLY_TAG))
                {
                    Shot();
                }
            }
        }
    }