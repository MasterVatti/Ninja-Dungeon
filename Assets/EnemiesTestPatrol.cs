using UnityEngine;
using UnityEngine.AI;

public class EnemiesTestPatrol : MonoBehaviour
{
    public bool IsOnPoint
    {
        get => _isOnPoint;
        set => _isOnPoint = value;
    }
    
    [SerializeField]
    private Transform[] _movePoints;
    [SerializeField]
    private float _startWaitTime;
    
    private NavMeshAgent _agent;
    
    private float _waitTime;
    private int _randomPoint;
    
    private bool _isOnPoint;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        _waitTime = _startWaitTime;
        _randomPoint = Random.Range(0, _movePoints.Length);
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        _agent.SetDestination(_movePoints[_randomPoint].transform.position);

        if (Vector3.Distance(gameObject.transform.position, _movePoints[_randomPoint].transform.position) < 1f)
        {
            if (_waitTime <= 0)
            {
                _randomPoint = Random.Range(0, _movePoints.Length);
                _waitTime = _startWaitTime;
                _isOnPoint = true;
            }
            else
            {
                _isOnPoint = false;
                _waitTime -= Time.deltaTime;   
            }
        }
    }
}