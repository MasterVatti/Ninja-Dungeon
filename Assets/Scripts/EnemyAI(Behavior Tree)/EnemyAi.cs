using System.Collections.Generic;
using Assets.Scripts;
using Nodes;
using UnityEngine;
using UnityEngine.AI;   

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float _startingHealth;
    [SerializeField]
    private float _lowHealthThreshold;
    
    [SerializeField]
    private float _shootingRange;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _shotCooldownTime;
    [SerializeField]
    private int _sequenceShots;

    [SerializeField]
    private GameObject _golemPrefab;

    [SerializeField]
    private float _runBackDistance;
    [SerializeField]
    private float _chasingRange;

    private NavMeshAgent _agent;
    private GameObject _player;
    private Transform _playerTransform;
    private Node _topNode;
    private Material material;
    private float _nextShotTime;
    private float _currentHealth;

    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag(GlobalConstants.PLAYER_TAG);
        _playerTransform = _player.transform;
        _currentHealth = _startingHealth;
        ConstructBehaviorTree();
    }

    private void ConstructBehaviorTree()
    {
        var isHealthEnoughNode = new IsHealthEnoughNode(this, _lowHealthThreshold);
        var golemSpawnNode = new GolemSpawnerNode(this);
        var rangeNode = new RangeNode(_shootingRange, _playerTransform, _agent.transform);
        var runBackNode = new RunBackNode(_runBackDistance, _agent, this);
        var shootNode = new ShootNode(this, _agent);
        var chasingRangeNode = new RangeNode(_chasingRange, _playerTransform, _agent.transform);
        var chaseNode = new ChaseNode(_playerTransform, _agent, this);

        var shootingSequence = new Selector(new List<Node> {shootNode, runBackNode, shootNode});

        var chaseSequence = new Sequence(new List<Node> {chasingRangeNode, chaseNode});
        var attackSequence = new Sequence(new List<Node> {rangeNode, shootingSequence},5f);
        var functionalSequence = new Sequence(new List<Node> {isHealthEnoughNode, golemSpawnNode});

        _topNode = new Selector(new List<Node> {functionalSequence, attackSequence, chaseSequence});
    }

    private void Update()
    {
        _topNode.Evaluate();
        if (_topNode.NodeState == NodeState.Failure)
        {
            SetColor(Color.white);
            _agent.isStopped = true;
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void GolemCreate()
    {
        var golem = Instantiate(_golemPrefab, gameObject.transform.position, Quaternion.identity);
    }

    public void Shot()
    {
        for (var i = 0; i < _sequenceShots && Time.time > _nextShotTime; i++)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            // Додумать более правильную механику стрельбы
            gameObject.transform.LookAt(_playerTransform);

            //Если будет оружие сдееллать инстантейтить от него
            var newBullet = Instantiate(_bulletPrefab, gameObject.transform.position,
                gameObject.transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * _bulletSpeed;
        }
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }
}