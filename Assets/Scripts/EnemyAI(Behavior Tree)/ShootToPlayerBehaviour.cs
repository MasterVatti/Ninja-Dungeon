using System;
using Assets.Scripts;
using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за дальние атаки врагов
/// </summary>
public class ShootToPlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _shotCooldownTime;
    [SerializeField]
    private NavMeshAgent _agent;

    private ObjectPool _objectPool;
    private GameObject _player;
    private float _nextShotTime;
    private int _reboundNumber;
    private void Start()
    {
        _player = MainManager.Player;

        _objectPool = new ObjectPool(_bulletPrefab.gameObject);
    }

    private void Shot()
    {
        _agent.isStopped = true;
        if (Time.time > _nextShotTime)
        { 
            _nextShotTime = Time.time + _shotCooldownTime;
            
            gameObject.transform.LookAt(_player.transform.position);
            
            CreateBullet();
        }

        Task.current.Succeed();
    }

    private void CreateBullet()
    {
        var newBullet = _objectPool.Get();

        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;

        
        var direction = (_player.transform.position - transform.position).normalized;
        
        if (newBullet.TryGetComponent<EnemyProjectile>(out var projectile))
        {
            projectile.Initialize(direction);
        }
        else
        {
            throw new ArgumentNullException("На снаряде нету Projectile");
        }
    }

    [Task]
    private void Shooting()
    {
        var directionToPlayer = _player.transform.position - transform.position;

        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out var hit))
        {
            if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                Shot();
            }
        }
    }
}