using UnityEngine;

namespace Nodes
{
    public class GolemSpawnerNode : Node
    {
        private GameObject _golemPrefab;
        private Transform _origin;
        private bool _isGolemCreate;

        public GolemSpawnerNode(GameObject golemPrefab, Transform enemyTransform)
        {
            _golemPrefab = golemPrefab;
            _origin = enemyTransform;
        }

        public override NodeState Evaluate()
        {
            if (!_isGolemCreate)
            {
                Object.Instantiate(_golemPrefab, _origin.position, Quaternion.identity);
                _isGolemCreate = true;
            }

            return NodeState.Failure;
        }
        
    }
}
