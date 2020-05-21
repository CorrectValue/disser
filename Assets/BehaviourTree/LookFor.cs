using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public sealed class LookFor : BaseBehaviourTreeNode
    {
        public InVariable<int> targetObject { get; set; } //enumerated consumable: food, water or medkit
        public InVariable<GameObject> actor { get; set; } //reference to an actor
        public OutVariable<Vector3> Output { get; set; } //out coordinates of an object found

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            var scr = actor.Get().GetComponent<fieldOfView>();
            Vector3 coords = new Vector3();
            //check if an actor has the targetobject in fov
            coords = scr.checkObjectPresenceInFOV(targetObject);
            if (coords.y == -100)
                return NodeState.Failure;
            else
            {
                Output.Set(coords);
                return NodeState.Success;
            }
        }
    }
}