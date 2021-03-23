using UnityEngine;

namespace Nodes
{
    public class GolemSpawnerNode : Node
    {
        private EnemyAi _enemyAi;
        private bool _isGolemCreate;

        public GolemSpawnerNode( EnemyAi enemyAi)
        {
            _enemyAi = enemyAi;
        }

        public override NodeState Evaluate()
        {
            if (!_isGolemCreate)
            {
                _enemyAi.GolemCreate();
                _isGolemCreate = true;
            }

            return NodeState.Failure;
        }
        
    }
}
