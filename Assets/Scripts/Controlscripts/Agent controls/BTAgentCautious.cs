using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class BTAgentCautious : MonoBehaviour
{

    private IBehaviourTreeNode _tree;
    private SimpleContext _context;

    // Start is called before the first frame update
    void Start()
    {
        _context = new SimpleContext(gameObject);

        var moveTarget = new Variable<Vector3>();
        var waitTime = new Variable<float>();
        var scr = gameObject.GetComponent<agentStateController>();
        var scr2 = gameObject.GetComponent<agentType>();
        int target;
        Variable<Vector3> objCoords = new Variable<Vector3>();
        Variable<GameObject> obj = new Variable<GameObject>();

        _tree = new RepeatForever
        {
            //construct the whole behavior tree
            //check if an agent is alive in the first place
            new CheckAlive
            {
                //here I need a switch to different paths basing on current agent condition
                new Selector
                {
                    //path 0: leave danger zone!
                    new CheckDanger
                    {
                        new Sequence
                        {
                            //generate point out of danger
                            new GetRandomPoint { Radius = 139, Output = moveTarget },
                            new RotateTo { Target = moveTarget },
                            new MoveTo { Target = moveTarget }
                        }
                    },
                    new CheckDying
                    {
                        //1st path - low HP
                        //urge to heal
                        new Sequence
                        {
                            new DebugLog { Str = "I'm on low HP" },
                            new Selector
                            {
                                //get out of danger zone
                                new Invert
                                {
                                    new Sequence
                                    {
                                        //generate a point out of danger zone
                                        new GetRandomPoint { Radius = 139, Output = moveTarget }, //fix the coordinate
                                        //move to
                                        new MoveTo { Target = moveTarget }
                                    }
                                },
                                new Selector
                                {
                                    new Consume { Consumable = 2 },
                                    new Sequence
                                    {
                                        //search for object
                                        new Selector
                                        {
                                            //an object is present in the field of view of an agent
                                            new Sequence
                                            {
                                                //check object presence in the field of view
                                                new LookFor { targetObject = 2, Output = objCoords, OutputObj = obj},
                                                //get object coordinates
                                                new RotateTo { Target = objCoords },
                                                new MoveTo { Target = objCoords },
                                                //grab an object and store it
                                                new PickUp { Object = obj }
                                            },

                                            //an object is nowhere to be found close
                                            new Sequence
                                            {
                                                new RepeatUntilSuccess
                                                {
                                                    new Sequence
                                                    {
                                                        new GetRandomPoint { Radius = 139, Output = moveTarget }, 
                                                        new RotateTo { Target = moveTarget },
                                                        new MoveTo { Target = moveTarget },
                                                        //look for an object on the fov
                                                        new LookFor { targetObject = 2, Output = objCoords, OutputObj = obj}
                                                    }
                                                },
                                                //get object coordinates
                                                new RotateTo { Target = objCoords },
                                                new MoveTo { Target = objCoords },
                                                //grab an object and store it
                                                new PickUp { Object = obj }
                                            }
                                        },
                                        new Consume { Consumable = 2 }
                                    }
                                }
                            }
                        }
                    },
                    new CheckThirsty
                    {
                        //2nd path - low hydration
                        //urge to drink something
                        new Sequence
                        {
                            new Selector
                            {
                                new Consume { Consumable = 1 },
                                new Sequence
                                {
                                    //search for object
                                    new Selector
                                    {
            
                                        //an object is present in the field of view of an agent
                                        new Sequence
                                        {
                                            //check object presence in the field of view
                                            new LookFor { targetObject = 1, Output = objCoords, OutputObj = obj},
                                            //get object coordinates
                                            new RotateTo { Target = objCoords },
                                            new MoveTo { Target = objCoords },
                                            //grab an object and store it
                                            new PickUp { Object = obj }
                                        },
                                        //an object is nowhere to be found close
                                        new Sequence
                                        {
                                            new RepeatUntilSuccess
                                            {
                                                new Sequence
                                                {
                                                    new GetRandomPoint { Radius = 139, Output = moveTarget }, 
                                                    new RotateTo { Target = moveTarget },
                                                    new MoveTo { Target = moveTarget },
                                                    //look for an object on the fov
                                                    new LookFor { targetObject = 1, Output = objCoords, OutputObj = obj}
                                                }
                                            },
                                            //get object coordinates
                                            new RotateTo { Target = objCoords },
                                            new MoveTo { Target = objCoords },
                                            //grab an object and store it
                                            new PickUp { Object = obj }
                                        }
                                    },
                                    new Consume { Consumable = 1 }
                                }
                            }
                        }
                    },
                    new CheckHungry
                    {
                        //3rd path - low satiety
                        //urge to eat something
                        new Sequence
                        {
                            new Selector
                            {
                                new Consume { Consumable = 0 },
                                new Sequence
                                {
                                    //search for object
                                    new Selector
                                    {
                                        //an object is present in the field of view of an agent
                                        new Sequence
                                        {
                                            //check object presence in the field of view
                                            new LookFor { targetObject = 0, Output = objCoords, OutputObj = obj},
                                            //get object coordinates
                                            new RotateTo { Target = objCoords },
                                            new MoveTo { Target = objCoords },
                                            //grab an object and store it
                                            new PickUp { Object = obj }
                                        },
                                        //an object is nowhere to be found close
                                        new Sequence
                                        {
                                            new RepeatUntilSuccess
                                            {
                                                new Sequence
                                                {
                                                    new GetRandomPoint { Radius = 139, Output = moveTarget }, 
                                                    new RotateTo { Target = moveTarget },
                                                    new MoveTo { Target = moveTarget },
                                                    //look for an object on the fov
                                                    new LookFor { targetObject = 0, Output = objCoords, OutputObj = obj}
                                                }
                                            },
                                            //get object coordinates
                                            new RotateTo { Target = objCoords },
                                            new MoveTo { Target = objCoords },
                                            //grab an object and store it
                                            new PickUp { Object = obj }
                                        }
                                    },
                                    new Consume { Consumable = 0 }
                                }
                            }
                        }
                    },
                    //4th path - no conditions
                    //can proceed to search for objects
                    new Sequence
                    {
                        new Selector
                        {
                            //an object is present in the field of view of an agent
                            new Sequence
                            {
                                //check object presence in the field of view
                                new LookFor { targetObject = 3, Output = objCoords, OutputObj = obj},
                                //get object coordinates
                                new RotateTo { Target = objCoords },
                                new MoveTo { Target = objCoords },
                                //grab an object and store it
                                new PickUp { Object = obj }
                            },
                            //an object is nowhere to be found close
                            new Sequence
                            {
                                new RepeatUntilSuccess
                                {
                                    new Sequence
                                    {
                                        new GetRandomPoint { Radius = 139, Output = moveTarget },
                                        new RotateTo { Target = moveTarget },
                                        new MoveTo { Target = moveTarget },
                                        //look for an object on the fov
                                        new LookFor { targetObject = 3, Output = objCoords, OutputObj = obj}
                                    }
                                },
                                //get object coordinates
                                new RotateTo { Target = objCoords },
                                new MoveTo { Target = objCoords },
                                //grab an object and store it
                                new PickUp { Object = obj }
                            }
                        }
                    }
                }
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        _tree.Execute(_context);
    }
}
