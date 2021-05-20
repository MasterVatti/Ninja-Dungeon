using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за следованием за Игроком.
/// </summary>
public class FollowBehavior : MonoBehaviour
{
    [SerializeField]
    private float _stopFollowingDistance;
    [SerializeField]
    private float _guardsDistance = 3;
    [SerializeField]
    private NavMeshAgent _agent;

    private GameObject _player;

    private void Start()
    {
        _player = MainManager.Player;
    }

    [Task]
    private void FollowPlayer()
    {
        var distance = Vector3.Distance(_player.transform.position, _agent.transform.position);

        if (distance >= _stopFollowingDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(GetRandomFollowingPoint());
        }
        else
        {
            Task.current.Succeed();
        }
    }

    private Vector3 GetRandomFollowingPoint()
    {
        var offsetX = Random.Range(-_guardsDistance, _guardsDistance);
        return _player.transform.TransformPoint(offsetX, 0, 0 - _guardsDistance);
    }

    [Task]
    private bool IsTherePlayer()
    {
        return _player != null;
    }
}