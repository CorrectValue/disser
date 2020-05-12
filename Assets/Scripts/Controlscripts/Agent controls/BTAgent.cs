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

        _tree = new RepeatForever
        {
            //construct the whole behavior tree
            //here I need a switch to different paths basing on current agent condition
            //1st path - low satiety
            //urge to eat something
            new Selector
            {
                new Consume { Consumable = 0 },
                new Sequence
                {
                    //search for object
                    //add to inventory
                    new Consume { Consumable = 0 }
                },
            },

            //2nd path - low hydration
            //urge to drink something
            new Selector
            {
                new Consume { Consumable = 1 },
                new Sequence
                {
                    //search for object
                    //add to inventory
                    new Consume { Consumable = 1 }
                },
            },

            //3rd path - low HP
            //urge to heal
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
                     },
                },
            },
            
            //4th path - no conditions
            //can proceed to search for objects

            new Sequence
            {
                new GetRandomPoint { Radius = 139, Output = moveTarget },
                new RotateTo { Target = moveTarget },
                new MoveTo { Target = moveTarget },
                new GetRandomFloat { Min = 0.5f, Max = 2f, Output = waitTime },
                new Wait { Time = waitTime}
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        _tree.Execute(_context);
    }
}
