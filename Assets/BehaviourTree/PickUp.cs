using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //pick up an object and store it
    public sealed class PickUp : BaseBehaviourTreeNode
    {
        public InVariable<GameObject> Object { get; set; }

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            var actor = sc.Actor;
            //invoke other script's pickup method
            actor.GetComponent<itemManager>().pickUp(Object.Get());
            Debug.Log("Picked up!");
            return NodeState.Success;
        }
    }
}