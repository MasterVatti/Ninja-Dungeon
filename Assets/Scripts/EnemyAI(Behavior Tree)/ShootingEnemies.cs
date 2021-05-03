using Assets.Scripts;
using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за дальние атаки врагов
/// </summary>
public class ShootingEnemies : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _bulletPrefab;

    [SerializeField]
    private GameObject _projectileStartPosition;
    
    [SerializeField]
    private float _bulletSpeed;
    
    [SerializeField]
    private float _shotCooldownTime;
    
    [SerializeField]
    private NavMeshAgent _agent;

    private GameObject _player;
    private float _nextShotTime;

    private void Start()
    {
        _player = MainManager.Player;
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
        var newBullet = Instantiate(_bulletPrefab, _projectileStartPosition.transform.position,
            transform.rotation);

        newBullet.velocity = transform.forward * _bulletSpeed;
    }

    [Task]
    private void Shooting()
    {
        var directionToPlayer = _player.transform.position - _projectileStartPosition.transform.position;

        if (Physics.Raycast(_projectileStartPosition.transform.position, directionToPlayer.normalized, out var hit))
        {
            if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                Shot();
            }
        }
    }
}