using UnityEngine;
using UnityEngine.AI;

namespace Nodes
{
    public class RunBackNode : Node
    {
        private readonly float _distance;
        private readonly NavMeshAgent _agent;
        private EnemyAi _enemyAi;

        public RunBackNode(float distance, NavMeshAgent agent, EnemyAi enemyAi)
        {
            _distance = distance;
            _agent = agent;
            _enemyAi = enemyAi;
        }

        public override NodeState Evaluate()
        {
            _enemyAi.SetColor(Color.green);
            
            _agent.isStopped = false;
            
            var position = new Vector3(_agent.transform.position.x, _agent.transform.position.y, 
                _agent.transform.position.z +_distance);
            
            _agent.SetDestination(position);
            
            return NodeState.Running;
        }
    }
}
