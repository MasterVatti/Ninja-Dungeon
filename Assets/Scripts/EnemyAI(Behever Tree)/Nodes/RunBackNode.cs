using UnityEngine;

namespace Nodes
{
    public class RunBackNode : Node
    {
        private Transform _playerPosition;
        

        public RunBackNode(Transform playerPosition)
        {
            _playerPosition = playerPosition;
        }

        public override NodeState Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}
