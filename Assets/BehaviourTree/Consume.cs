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
            var actor = sc.Actor;
            //check if an actor has sth to eat
            switch(Consumable)
            {
                case 0:
                    //food
                    //consume stored food
                    actor.GetComponent<agentStateController>().eat();
                    break;
                case 1:
                    //water
                    //consume stored water
                    actor.GetComponent<agentStateController>().drink();
                    break;
                case 2:
                    //medkit
                    //consume stored medkit
                    actor.GetComponent<agentStateController>().heal();
                    break;
                default:
                    break;
            }

            return NodeState.Success;
        }
    }
}