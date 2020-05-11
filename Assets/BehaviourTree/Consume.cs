using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public sealed class Consume : BaseBehaviourTreeNode
    {
        public InVariable<int> Consumable { get; set; } //enumerated consumable: food, water or medkit

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            //check if an actor has sth to eat
            switch(Consumable)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }

            return distance < 0.01f
                ? NodeState.Success
                : NodeState.Running;
        }
    }
}