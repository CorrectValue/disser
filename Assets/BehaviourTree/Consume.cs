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
                    if (actor.GetComponent<itemManager>().foodStored)
                        actor.GetComponent<agentStateController>().eat();
                    else
                        return NodeState.Failure;
                    break;
                case 1:
                    //water
                    //consume stored water
                    if (actor.GetComponent<itemManager>().waterStored)
                        actor.GetComponent<agentStateController>().drink();
                    else
                        return NodeState.Failure;
                    break;
                case 2:
                    //medkit
                    //consume stored medkit
                    if (actor.GetComponent<itemManager>().medkitStored)
                        actor.GetComponent<agentStateController>().heal();
                    else
                        return NodeState.Failure;
                    break;
                default:
                    break;
            }

            return NodeState.Success;
        }
    }
}