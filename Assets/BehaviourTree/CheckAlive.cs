using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

namespace BehaviourTrees
{
    public class CheckAlive : Decorator
    {

        protected override NodeState OnRunning(ExecutionContext context)
        {

            SimpleContext cxt = (SimpleContext)context;

            var actor = cxt.Actor;
            var scr = actor.GetComponent<agentStateController>();
            var condition = Bindings.Create(() => scr.isDead());

            if(!condition.Get())
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
}