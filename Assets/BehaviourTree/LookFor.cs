using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public sealed class LookFor : BaseBehaviourTreeNode
    {
        public InVariable<int> targetObject { get; set; } //enumerated consumable: food, water or medkit
        public OutVariable<Vector3> Output { get; set; } //out coordinates of an object found
        public OutVariable<GameObject> OutputObj { get; set; } //out coordinates of an object found

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            var actor = sc.Actor;
            var scr = actor.GetComponent<fieldOfView>();
            Vector3 coords = new Vector3();
            GameObject obj;

            Debug.Log("Look for " + targetObject.Get().ToString());

            //check if an actor has the targetobject in fov
            obj = scr.checkObjectPresenceInFOV(targetObject.Get());

            if (obj == null)
            {
                Debug.Log("LookFor: no object found, looking for " + targetObject.Get().ToString());
                return NodeState.Failure;
            }
            else
            {
                Debug.Log("LookFor: object found, looking for " + targetObject.Get().ToString());
                coords = obj.transform.position;
                Output.Set(coords);
                OutputObj.Set(obj);
                return NodeState.Success;
            }
        }
    }
}