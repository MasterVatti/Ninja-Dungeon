using Assets.Scripts;
using Enemies;
using Panda;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Отвечает за базовые навыки(Таски) Врага передвежение и хп. Должен висеть на всех енеми.
/// </summary>
public class Unit : MonoBehaviour
{
    public GameObject Player => _player;
    [SerializeField]
    private EnemyHealth _enemyHealth;
    [SerializeField]
    private float _lowHealthThreshold;
    
    private NavMeshAgent _agent;
    private GameObject _player;

    private Material material;
    private Vector3 _movePoint;

    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag(GlobalConstants.PLAYER_TAG);
        EnemiesManager.Singleton.Enemies.Add(gameObject);
    }

    public void ChangePointMovement(Vector3 movePoint)
    {
        _movePoint = movePoint;
    }
    
    public void SetColor(Color color) // Метод чисто для отладки.
    {
        material.color = color;
    }

    [Task]
    private void MoveToDestination()
    {
        MoveTo(_movePoint);
        WaitArrival();
    }

    [Task]
    private bool SetDestination(Vector3 p)
    {
        _movePoint = p;
        _agent.destination = _movePoint;

        if (Task.isInspected)
            Task.current.debugInfo = string.Format("({0}, {1})", _movePoint.x, _movePoint.y);
        return true;
    }

    [Task]
    private void MoveTo(Vector3 dst)
    {
        SetDestination(dst);
        if (Task.current.isStarting)
            _agent.isStopped = false;
        WaitArrival();
    }

    [Task]
    private void WaitArrival()
    {
        var task = Task.current;
        float distance = _agent.remainingDistance;
        if (!task.isStarting && _agent.remainingDistance <= 1f)
        {
            task.Succeed();
            distance = 0.0f;
        }

        if (Task.isInspected)
            task.debugInfo = string.Format("distance-{0:0.00}", distance);
    }
    
    [Task]
    private void Chase(float stopDistance)
    {
        var distance = Vector3.Distance(_player.transform.position, _agent.transform.position);

        if (distance >= stopDistance)
        {
            SetColor(Color.yellow);
            _agent.isStopped = false;
            _agent.SetDestination(_player.transform.position);
        }
        else
        {
            Task.current.Succeed();
        }
    }

    [Task]
    private bool IsHealthEnough()
    {
        return _enemyHealth.CurrentHealth <= _lowHealthThreshold;
    }

    [Task]
    private bool IsRequiredDistance(float distance)
    {
        var playerDistance = Vector3.Distance(_player.transform.position, _agent.transform.position);
        return playerDistance <= distance;
    }
}