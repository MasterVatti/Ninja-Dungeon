using UnityEngine;
using UnityEngine.AI;

namespace Nodes
{
    public class ChaseNode : Node
    {
        private readonly Transform _target;
        private readonly NavMeshAgent _agent;
        private EnemyAi _enemyAi;

        public ChaseNode(Transform target, NavMeshAgent agent,  EnemyAi ai)
        {
            _target = target;
            _agent = agent;
            _enemyAi = ai;
        }

        public override NodeState Evaluate()
        {
            var distance = Vector3.Distance(_target.position, _agent.transform.position);
            
            if (distance >= 7f)
            {
                _enemyAi.SetColor(Color.yellow);
                _agent.isStopped = false;
                _agent.SetDestination(_target.position);
                return NodeState.Running;
            }
            else
            {
                _enemyAi.SetColor(Color.red);
                _agent.isStopped = true;
                return NodeState.Success;
            }
        }
    }
}
