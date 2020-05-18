using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;


public class ConditionalSelector : Composite
{
    public InVariable<bool> condition { get; set; }
    protected override NodeState OnRunning(ExecutionContext context)
    {
        if(condition)
        {
            var child = Children[0];
            var childState = child.Execute(context);
            if (childState == NodeState.Success)
                return NodeState.Success;
            if (childState == NodeState.Running)
                return NodeState.Running;
        }
        else
        {
            var child = Children[1];
            var childState = child.Execute(context);
            if (childState == NodeState.Success)
                return NodeState.Success;
            if (childState == NodeState.Running)
                return NodeState.Running;
        }

        return NodeState.Failure;
    }
}

