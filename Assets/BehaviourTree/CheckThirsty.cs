using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class CheckThirsty : Decorator
{
    public InVariable<GameObject> actor { get; set; }

    protected override NodeState OnRunning(ExecutionContext context)
    {
        SimpleContext cxt = (SimpleContext)context;

        var actor = cxt.Actor;
        var scr = actor.GetComponent<agentStateController>();
        var condition = Bindings.Create(() => scr.isThirsty());
        if (condition.Get())
        {
            Child.Execute(context);
            return Child.State;
        }
        else
        {
            return NodeState.Failure;
        }
    }
}
