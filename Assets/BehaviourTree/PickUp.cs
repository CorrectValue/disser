using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    //pick up an object and store it
    public sealed class PickUp : BaseBehaviourTreeNode
    {
        public InVariable<int> Object { get; set; }
        public InVariable<GameObject> actor { get; set; } //reference to an actor

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;

            //switch type of object
            switch(Object)
            {
                case 0:
                    //food

                    break;
                case 1:
                    //water
                    break;
                case 2:
                    //medkit
                    break;
            }

            //empty for now
            return NodeState.Success;
        }
    }
}