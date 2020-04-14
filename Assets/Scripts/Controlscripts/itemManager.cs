using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    //this script serves to maintain items collected by an agent
    bool medkitStored;
    // Start is called before the first frame update
    void Start()
    {
        medkitStored = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickUp(GameObject item)
    {
        //pick up an object and store or use it
        //first, need to determine type of an object we're about to consume
        //an item has a tag. get it
        if(item.tag == "collectable")
        {
            //pick up a collectable object and increase own points value

        }
        else if(item.tag == "medkit")
        {
            //pick up a medkit and store it

        }
        else if(item.tag == "food")
        {
            //pick up and eat

        }
        else if(item.tag == "water")
        {
            //pick up and drink

        }
        //and then in any case we destroy the object we've picked up
        Destroy(item);
    }
}
