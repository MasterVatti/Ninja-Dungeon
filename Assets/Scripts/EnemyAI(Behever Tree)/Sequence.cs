using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes;
    
    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }
    
    public override NodeState Evaluate()
    {
        var isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    isAnyNodeRunning = true;
                    break;
                case NodeState.Success:
                    break;
                case NodeState.Failure:
                    return _nodeState;
            }
        }

        _nodeState = isAnyNodeRunning ? NodeState.Running : NodeState.Success;
        return _nodeState;
    }
}
