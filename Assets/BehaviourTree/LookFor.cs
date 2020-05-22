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
        public OutVariable<GameObject> OutputObj { get; set; } //out coordinates of an object found

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            var scr = actor.Get().GetComponent<fieldOfView>();
            Vector3 coords = new Vector3();
            GameObject obj;
            Debug.Log("LookFor");
            //check if an actor has the targetobject in fov
            obj = scr.checkObjectPresenceInFOV(targetObject);
            coords = obj.transform.position;
            Debug.Log("We're here");
            if (obj == null)
                return NodeState.Failure;
            else
            {
                Output.Set(coords);
                OutputObj.Set(obj);
                return NodeState.Success;
            }
        }
    }
}