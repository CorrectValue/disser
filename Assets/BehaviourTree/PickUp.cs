using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //pick up an object and store it
    public sealed class PickUp : BaseBehaviourTreeNode
    {
        public InVariable<int> Object { get; set; }

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            
            return distance < 0.01f
                ? NodeState.Success
                : NodeState.Running;
        }
    }
}