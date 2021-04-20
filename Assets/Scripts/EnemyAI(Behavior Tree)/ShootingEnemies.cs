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
    private GameObject _bulletPrefab;
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
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            gameObject.transform.LookAt(_player.transform.position);
            _agent.isStopped = true;

            var newBullet = Instantiate(_bulletPrefab, transform.position,
                transform.rotation);
            
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;
        }
        Task.current.Succeed();
    }

    [Task]
    private void Shooting()
    {
        var directionToPlayer = _player.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit))
        {
            if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                Shot();
            }
        }
    }
}