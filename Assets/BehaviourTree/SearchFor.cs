﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public sealed class SearchFor : BaseBehaviourTreeNode
{
    //takes a type of object to search for and proceeds searching until finds it
    private IBehaviourTreeNode _tree;
    private SimpleContext _context;

    public InVariable<int> searchTarget { get; set; } //enumerated search target: food, water, medkit or collectable (1-3-5-10)
    public InVariable<GameObject> Actor { get; set; } //enumerated search target: food, water, medkit or collectable (1-3-5-10)

    
    Variable<Vector3> moveTarget = new Variable<Vector3>();
    Variable<Vector3> objCoords = new Variable<Vector3>();
    Variable<GameObject> obj = new Variable<GameObject>();

    void Start()
    {
        _tree = new Selector
        {
            new DebugLog { },
            //an object is present in the field of view of an agent
            new Sequence
            {
                
                //check object presence in the field of view
                new LookFor { targetObject = searchTarget,  Output = objCoords, OutputObj = obj},
                //get object coordinates
                new RotateTo { Target = moveTarget },
                new MoveTo { Target = objCoords },
                //grab an object and store it
                new PickUp { Object = obj, actor = Actor }

            },

            //an object is nowhere to be found close
            new Sequence
            {
                new RepeatUntilSuccess
                {
                    new Sequence
                    {
                        new GetRandomPoint { Radius = 139, Output = moveTarget }, //Radius must depend on agent type and type of object to search for!
                        //parallel!
                        new RotateTo { Target = moveTarget },
                        new MoveTo { Target = moveTarget },
                        //look for an object on the fov
                        new LookFor { targetObject = searchTarget,  Output = objCoords}
                        //once an object is found, return success
                        
                    }
                },

                //get object coordinates
                new RotateTo { Target = objCoords },
                new MoveTo { Target = objCoords },
                //grab an object and store it
                new PickUp { Object = obj, actor = Actor }
            }
        };
    }
    protected override NodeState OnRunning(ExecutionContext context)
    {

        _tree.Execute(context);

        //SimpleContext sc = (SimpleContext)context;

        

        return NodeState.Success;

    }
}
