using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //pick up an object and store it
    public sealed class SetSearchTarget : BaseBehaviourTreeNode
    {
        public InVariable<int> Target { get; set; }

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            var actor = sc.Actor;
            var target = Bindings.Create(() => Target.Get());
            //invoke other script's pickup method
            actor.GetComponent<agentStateController>().searchTarget = target.Get();
            return NodeState.Success;
        }
    }
}