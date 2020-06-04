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
                
                //new DebugLog { Str = "I'm alive?" },
                //here I need a switch to different paths basing on current agent condition
                new Selector
                {
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
                                        new DebugLog { Str = "Searching for medkit" },
                                        new Selector
                                        {
            
                                            //an object is present in the field of view of an agent
                                            new Sequence
                                            {
                                                //check object presence in the field of view
                                                new LookFor { targetObject = 2, Output = objCoords, OutputObj = obj},
                                                //get object coordinates
                                                //new DebugLog { Str = "Target is " + target.ToString() }, //здесь 0
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
                                                        new GetRandomPoint { Radius = 139, Output = moveTarget }, //Radius must depend on agent type and type of object to search for!
                                                        //parallel!
                                                        new RotateTo { Target = moveTarget },
                                                        new MoveTo { Target = moveTarget },
                                                        //look for an object on the fov
                                                        new LookFor { targetObject = 2, Output = objCoords, OutputObj = obj}
                                                        //once an object is found, return success
                        
                                                    }
                                                },

                                                //get object coordinates
                                                new RotateTo { Target = objCoords },
                                                new MoveTo { Target = objCoords },
                                                //grab an object and store it
                                                new PickUp { Object = obj }
                                            }
                                        },
                                        //add to inventory

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
                            new DebugLog { Str = "I'm thirsty" },
                            new Selector
                            {
                                new Consume { Consumable = 1 },
                                new Sequence
                                {
                                    //search for object
                                    new DebugLog { Str = "Searching for water" },
                                    new Selector
                                    {
            
                                        //an object is present in the field of view of an agent
                                        new Sequence
                                        {
                                            //check object presence in the field of view
                                            new LookFor { targetObject = 1, Output = objCoords, OutputObj = obj},
                                            //get object coordinates
                                            //new DebugLog { Str = "Target is " + target.ToString() }, //здесь 0
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
                                                    new LookFor { targetObject = 1, Output = objCoords, OutputObj = obj}
                                                    //once an object is found, return success
                        
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
                            new DebugLog { Str = "I'm hungry" },
                            new Selector
                            {
                                new Consume { Consumable = 0 },
                                new Sequence
                                {
                                    //search for object
                                    new DebugLog { Str = "Searching for food" },
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
                                                    new LookFor { targetObject = 0, Output = objCoords, OutputObj = obj}
                                                    //once an object is found, return success
                        
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

                    new CheckOk
                    {
                        //4th path - no conditions
                        //can proceed to search for objects
                        //1 - cautious population
                        //need to stay out of the center
                        new Sequence
                        {
                            new GetRandomPoint { Radius = 139, Output = moveTarget },
                            new RotateTo { Target = moveTarget },
                            new MoveTo { Target = moveTarget },
                            new GetRandomFloat { Min = 0.5f, Max = 2f, Output = waitTime },
                            new Wait { Time = waitTime}
                        },
                        
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
