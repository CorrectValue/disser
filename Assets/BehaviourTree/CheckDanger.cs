using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

namespace BehaviourTrees
{
    public class CheckDanger : Decorator
    {
        protected override NodeState OnRunning(ExecutionContext context)
        {
            SimpleContext cxt = (SimpleContext)context;
            var transform = cxt.Actor.transform;
            Vector3 center = new Vector3(0, 0, 0);
            var distance = Vector3.Distance(transform.position, center);
            if (distance < 51.0f)
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