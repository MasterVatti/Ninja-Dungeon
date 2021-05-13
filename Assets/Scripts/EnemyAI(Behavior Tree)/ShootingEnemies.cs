using Assets.Scripts;
using Characteristics;
using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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
    private Unit _unit;
    
    private float _nextShotTime;
    private int _damage;

    private void Awake()
    {
        _damage = _unit.Characteristics.AttackDamage;
    }

    private void Shot()
    {
        _agent.isStopped = true;
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            gameObject.transform.LookAt(_unit.TargetProvider.ProvideTarget()
                .transform.position);


            CreateBullet();
            
            Task.current.Succeed();
        }
    }

    private void CreateBullet()
    {
        var newBullet = Instantiate(_bulletPrefab, transform.position,
            transform.rotation);
        var nearestTargetDirection = (_unit.TargetProvider.ProvideTarget()
            .transform.position- transform.position).normalized;
       
        newBullet.Initialize(nearestTargetDirection, _damage);
    }


    [Task]
    private void Shooting()
    {
        var directionToTarget = _unit.TargetProvider.ProvideTarget()
            .transform.position - transform.position;

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