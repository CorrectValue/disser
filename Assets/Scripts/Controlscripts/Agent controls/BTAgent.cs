using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class BTAgent : MonoBehaviour
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
        _tree = new RepeatForever
        {
            //construct the whole behavior tree
            //check if an agent is alive in the first place
            new CheckAlive
            {
                //here I need a switch to different paths basing on current agent condition
                new Selector
                {
                    new CheckDying
                    {
                        //1st path - low HP
                        //urge to heal
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
                                    //add to inventory
                                    new Consume { Consumable = 2 }
                                }
                            }
                        }
                    },

                    new CheckThirsty
                    {
                        //2nd path - low hydration
                        //urge to drink something
                        new DebugLog { Str = "I'm thirsty" },
                        new Selector
                        {
                            new Consume { Consumable = 1 },
                            new Sequence
                            {
                                //search for object
                                new SearchFor { searchTarget = 1 },
                                new Consume { Consumable = 1 }
                            }
                        }
                    },

                    new CheckHungry
                    {
                        //3rd path - low satiety
                        //urge to eat something
                        new DebugLog { Str = "I'm hungry" },
                        new Selector
                        {
                            new Consume { Consumable = 0 },
                            new Sequence
                            {
                                //search for object
                                new SearchFor { searchTarget = 0 },
                                new Consume { Consumable = 0 }
                            }
                        }
                    },

                    new CheckOk
                    {
                        //4th path - no conditions
                        //can proceed to search for objects
                        //switch strategy based on the type of an actor
                        new CheckType
                        {
                            //0 - clever population
                            new Sequence
                            {
                                new GetRandomPoint { Radius = 139, Output = moveTarget },
                                new RotateTo { Target = moveTarget },
                                new MoveTo { Target = moveTarget },
                                new GetRandomFloat { Min = 0.5f, Max = 2f, Output = waitTime },
                                new Wait { Time = waitTime}
                            },
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
                            //2 - balanced population
                            //true random 
                            new Sequence
                            {
                                new DebugLog { Str = "Searching for goods" },
                                new SearchFor { searchTarget = 3 },
                            },
                            //3 - risky population
                            //tries to stay as close to the center as possible
                            new Sequence
                            {
                                //move to the center
                                new GetRandomPoint { Radius = 50, Output = moveTarget },
                                new RotateTo { Target = moveTarget },
                                new MoveTo { Target = moveTarget },
                                //search for goodies
                                new GetRandomFloat { Min = 0.5f, Max = 2f, Output = waitTime },
                                new Wait { Time = waitTime}
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
