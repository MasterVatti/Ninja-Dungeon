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
    private Unit _unit;

    private NavMeshAgent _agent;
    private GameObject _player;
    private float _nextShotTime;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag(GlobalConstants.PLAYER_TAG);
    }

    private void Shot()
    {
        
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            // Додумать более правильную механику стрельбы
            gameObject.transform.LookAt(_player.transform.position);

            //Если будет оружие сдееллать инстантейтить от него
            var newBullet = Instantiate(_bulletPrefab, gameObject.transform.position,
                gameObject.transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * _bulletSpeed;
        }

        Task.current.Succeed();
    }

    [Task]
    private void Shooting()
    {
        _agent.isStopped = true;
        _unit.SetColor(Color.blue);
        
        Shot();
    }
}