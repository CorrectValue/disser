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
            //urge to eat something
            new Selector
            {
                new Consume { Consumable = food },
                new Sequence
                {
                    //search for object
                    //add to inventory
                    new Consume { Consumable = food }
                },
            },

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
