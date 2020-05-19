using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

namespace BehaviourTrees
{
    public class CheckOk : Decorator
    {

        protected override NodeState OnRunning(ExecutionContext context)
        {

            SimpleContext cxt = (SimpleContext)context;

            var actor = cxt.Actor;
            var scr = actor.GetComponent<agentStateController>();
            var conditionDying = Bindings.Create(() => scr.isDying());
            var conditionHungry = Bindings.Create(() => scr.isHungry());
            var conditionThirsty = Bindings.Create(() => scr.isThirsty());


            if (!conditionDying.Get() && !conditionHungry.Get() && !conditionThirsty.Get())
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