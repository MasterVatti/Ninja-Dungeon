[System.Serializable]
public abstract class Node
{
    public NodeState NodeState => _nodeState;
    
    protected NodeState _nodeState;

    public abstract NodeState Evaluate();
}

public enum NodeState
{
    Running,
    Success,
    Failure,
}
