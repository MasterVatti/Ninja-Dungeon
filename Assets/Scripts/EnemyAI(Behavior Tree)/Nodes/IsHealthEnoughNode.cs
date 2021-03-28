namespace Nodes
{
    public class IsHealthEnoughNode : Node
    {
        private EnemyAi _enemyAi;
        private float _threshold;

        public IsHealthEnoughNode(EnemyAi ai, float threshold)
        {
            _enemyAi = ai;
            _threshold = threshold;

        }
        public override NodeState Evaluate()
        {
            return _enemyAi.GetCurrentHealth() <= _threshold ? NodeState.Success : NodeState.Failure;
        }
    }
}
