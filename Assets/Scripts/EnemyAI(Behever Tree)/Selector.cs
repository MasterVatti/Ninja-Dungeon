using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes;
    
    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }
    
    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    _nodeState = NodeState.Running;
                    return _nodeState;
                case NodeState.Success:
                    return _nodeState;
                case NodeState.Failure:
                    break;
            }
        }

        _nodeState = NodeState.Failure;
        return _nodeState;
    }
}
