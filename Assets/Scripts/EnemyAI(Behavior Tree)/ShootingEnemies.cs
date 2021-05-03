using Assets.Scripts;
using Characteristics;
using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за дальние атаки врагов
/// </summary>
public class ShootingEnemies : MonoBehaviour
{
    [SerializeField]
    private Projectile _bulletPrefab;
    [SerializeField]
    private float _shotCooldownTime;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private EnemyAI _enemyAI;
    
    private float _nextShotTime;
    private int _damage;

    private void Awake()
    {
        _damage = gameObject.GetComponent<PersonCharacteristics>().AttackDamage;
    }

    private void Shot()
    {
        _agent.isStopped = true;
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            gameObject.transform.LookAt(_enemyAI.Target.transform.position);


            CreateBullet();
            
            Task.current.Succeed();
        }
    }

    private void CreateBullet()
    {
        var newBullet = Instantiate(_bulletPrefab, transform.position,
            transform.rotation);
        var nearestTargetDirection = (_enemyAI.Target.transform.position- transform.position).normalized;
       
        newBullet.Initialize(nearestTargetDirection, _damage);
    }


    [Task]
    private void Shooting()
    {
        var directionToTarget = _enemyAI.Target.transform.position - transform.position;

        if (Physics.Raycast(transform.position, directionToTarget.normalized, out var hit))
        {
            if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG) ||
                hit.collider.CompareTag(GlobalConstants.ALLY_TAG))
            {
                Shot();
            }
        }
    }
}