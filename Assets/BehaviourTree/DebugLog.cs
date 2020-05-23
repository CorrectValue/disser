using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //needed for debugging
    
    public sealed class DebugLog : BaseBehaviourTreeNode
    {
        public InVariable<string> Str { get; set; }
        protected override NodeState OnRunning(ExecutionContext context)
        {
            Debug.Log(Str.Get());
            return NodeState.Success;
        }
    }
}