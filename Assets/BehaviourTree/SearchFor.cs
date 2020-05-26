using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public sealed class SearchFor : BaseBehaviourTreeNode
{
    //takes a type of object to search for and proceeds searching until finds it
    private IBehaviourTreeNode _tree;
    private SimpleContext _context;

    //public InVariable<int> searchTarget { get; set; } //enumerated search target: food, water, medkit or collectable (1-3-5-10)
    
    Variable<Vector3> moveTarget = new Variable<Vector3>();
    Variable<Vector3> objCoords = new Variable<Vector3>();
    Variable<GameObject> obj = new Variable<GameObject>();

    int target;

    public SearchFor()
    {
        //var target = Bindings.Create(() => searchTarget.Get());
        _tree = new Selector
        {
            
            //an object is present in the field of view of an agent
            new Sequence
            {
                //check object presence in the field of view
                new LookFor { targetObject = target, Output = objCoords, OutputObj = obj},
                //get object coordinates
                new DebugLog { Str = "Target is " + target.ToString() }, //здесь 0
                new RotateTo { Target = objCoords },
                new MoveTo { Target = objCoords },
                //grab an object and store it
                new PickUp { Object = obj }

            },

            //an object is nowhere to be found close
            new Sequence
            {
                //new DebugLog { Str = "Target is " + target.ToString() },
                new RepeatUntilSuccess
                {
                    new Sequence
                    {
                        new GetRandomPoint { Radius = 139, Output = moveTarget }, //Radius must depend on agent type and type of object to search for!
                        //parallel!
                        new RotateTo { Target = moveTarget },
                        new MoveTo { Target = moveTarget },
                        //look for an object on the fov
                        new LookFor { targetObject = target, Output = objCoords, OutputObj = obj}
                        //once an object is found, return success
                        
                    }
                },

                //get object coordinates
                new RotateTo { Target = objCoords },
                new MoveTo { Target = objCoords },
                //grab an object and store it
                new PickUp { Object = obj }
            }
        };
    }
    protected override NodeState OnRunning(ExecutionContext context)
    {
        var sc = (SimpleContext)_context;
        target = sc.Actor.GetComponent<agentStateController>().searchTarget;
        Debug.Log("Search for " + target.ToString()); //здесь 3
        _tree.Execute(context);

        //SimpleContext sc = (SimpleContext)context;

        return NodeState.Success;

    }
}
