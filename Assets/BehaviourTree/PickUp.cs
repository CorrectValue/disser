using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //pick up an object and store it
    public sealed class PickUp : BaseBehaviourTreeNode
    {
        public InVariable<GameObject> Object { get; set; }
        public InVariable<GameObject> actor { get; set; } //reference to an actor

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;

            //invoke other script's pickup method
            actor.Get().GetComponent<itemManager>().pickUp(Object.Get());

            return NodeState.Success;
        }
    }
}