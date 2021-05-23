using System;
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
public class ShootToPlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Projectile _bulletPrefab;
    [SerializeField]
    private float _shotCooldownTime;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private Unit _unit;

    private ObjectPool _objectPool;
    private GameObject _player;
    
    private float _nextShotTime;
    private int _reboundNumber;
    private int _damage;

    private void Awake()
    {
        _player = MainManager.Player;
        _damage = _unit.Characteristics.AttackDamage;
        _objectPool = new ObjectPool(_bulletPrefab.gameObject);
    }

    private void Shot()
    {
        _agent.isStopped = true;
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            transform.LookAt(_unit.TargetProvider.ProvideTarget()
                .transform.position);


            CreateBullet();
            
            Task.current.Succeed();
        }
    }

    private void CreateBullet()
    {
        var newBullet = _objectPool.Get();
        var nearestTargetDirection = (_unit.TargetProvider.ProvideTarget()
            .transform.position - transform.position).normalized;

        if (newBullet.TryGetComponent<EnemyProjectile>(out var projectile))
        {
            projectile.Initialize(nearestTargetDirection, _damage);
        }
        else
        {
            throw new ArgumentNullException("На снаряде нету Projectile");
        }
    }


    [Task]
    private void Shooting()
    {
        var target = _unit.TargetProvider.ProvideTarget();
        var directionToTarget = target.transform.position - transform.position;

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