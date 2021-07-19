using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за следованием за Игроком.
/// </summary>
public class FollowBehavior
{
    private readonly float _stopFollowingDistance;
    private readonly float _guardsDistance;
    private readonly NavMeshAgent _agent;
    private readonly Player _player;

    public FollowBehavior(NavMeshAgent agent, float stopFollowingDistance, float guardsDistance)
    {
        _stopFollowingDistance = stopFollowingDistance;
        _guardsDistance = guardsDistance;
        _agent = agent;
        _player = MainManager.Player;
    }
    
    public void FollowPlayer()
    {
        var distance = Vector3.Distance(_player.transform.position, _agent.transform.position);

        if (distance >= _stopFollowingDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(GetRandomFollowingPoint());
        }
        else
        {
            _agent.isStopped = true;
            Task.current.Succeed();
        }
    }
    
    private Vector3 GetRandomFollowingPoint()
    {
        var offsetX = Random.Range(-_guardsDistance, _guardsDistance);
        return _player.transform.TransformPoint(offsetX, 0, 0 - _guardsDistance);
    }
}