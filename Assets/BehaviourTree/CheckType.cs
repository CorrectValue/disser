using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

namespace BehaviourTrees
{
    public class CheckType : Composite
    {

        protected override NodeState OnRunning(ExecutionContext context)
        {

            SimpleContext cxt = (SimpleContext)context;

            var actor = cxt.Actor;
            var scr = actor.GetComponent<agentType>();
            var conditionType = Bindings.Create(() => scr.type);

            var Child = Children[conditionType.Get()];
            Child.Execute(context);
            return Child.State;
        }
    }
}