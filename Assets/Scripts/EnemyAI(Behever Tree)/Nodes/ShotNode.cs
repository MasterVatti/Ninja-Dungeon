using UnityEngine;

namespace Nodes
{
    public class ShotNode : Node
    {
        private EnemyAi _enemyAi;

        public ShotNode(EnemyAi enemyAi)
        {
            _enemyAi = enemyAi;
        }

        public override NodeState Evaluate()
        {
            _enemyAi.Shot();
            return NodeState.Success;
        }
        
    }
}
