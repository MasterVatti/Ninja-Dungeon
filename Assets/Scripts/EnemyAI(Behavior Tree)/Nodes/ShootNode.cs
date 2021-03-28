using UnityEngine;
using UnityEngine.AI;

namespace Nodes
{
    public class ShootNode : Node
    {
        private EnemyAi _enemyAi;
        private NavMeshAgent _agent;

        public ShootNode(EnemyAi enemyAi, NavMeshAgent agent)
        {
            _enemyAi = enemyAi;
            _agent = agent;
            
        }

        public override NodeState Evaluate()
        {
            _agent.isStopped = true;
            _enemyAi.TakeDamage(10); // Тут тест получения урона для энеми на дистанции атаки.
            _enemyAi.SetColor(Color.blue);
            
            _enemyAi.Shot();
            
            return NodeState.Running;
        }
        
    }
}
