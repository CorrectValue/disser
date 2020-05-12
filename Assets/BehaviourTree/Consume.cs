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
                    //food
                    //consume stored food
                    break;
                case 1:
                    //water
                    //consume stored water
                    break;
                case 2:
                    //medkit
                    //consume stored medkit
                    break;
                default:
                    break;
            }

            return NodeState.Success;
        }
    }
}