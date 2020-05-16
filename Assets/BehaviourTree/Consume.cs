using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public sealed class Consume : BaseBehaviourTreeNode
    {
        public InVariable<int> Consumable { get; set; } //enumerated consumable: food, water or medkit
        public InVariable<GameObject> actor { get; set; } //reference to an actor

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            //check if an actor has sth to eat
            switch(Consumable)
            {
                case 0:
                    //food
                    //consume stored food
                    actor.Get().GetComponent<agentStateController>().eat();
                    break;
                case 1:
                    //water
                    //consume stored water
                    actor.Get().GetComponent<agentStateController>().drink();
                    break;
                case 2:
                    //medkit
                    //consume stored medkit
                    actor.Get().GetComponent<agentStateController>().heal();
                    break;
                default:
                    break;
            }

            return NodeState.Success;
        }
    }
}