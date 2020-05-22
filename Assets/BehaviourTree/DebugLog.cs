using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //pick up an object and store it
    public sealed class DebugLog : BaseBehaviourTreeNode
    {
        
        protected override NodeState OnRunning(ExecutionContext context)
        {
            Debug.Log("I'm here!");
            return NodeState.Success;
        }
    }
}