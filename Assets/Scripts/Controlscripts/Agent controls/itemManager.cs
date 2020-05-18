using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    //this script serves to maintain items collected by an agent
    public bool medkitStored, foodStored, waterStored;
    
    // Start is called before the first frame update
    void Start()
    {
        medkitStored = false;
        foodStored = false;
        waterStored = false;
    }

    public void pickUp(GameObject item)
    {
        //pick up an object and store or use it
        //first, need to determine type of an object we're about to consume
        //an item has a tag. get it
        //and get the script component
        var scr = gameObject.GetComponent<agentStateController>();
        if (item.tag == "collectable1")
        {
            //pick up a collectable object and increase own points value
            scr.earnPoint(1);
        }
        else if (item.tag == "collectable3")
        {
            //pick up a collectable object and increase own points value
            scr.earnPoint(3);
        }
        else if (item.tag == "collectable5")
        {
            //pick up a collectable object and increase own points value
            scr.earnPoint(5);
        }
        else if (item.tag == "collectable10")
        {
            //pick up a collectable object and increase own points value
            scr.earnPoint(10);
        }
        else if(item.tag == "medkit")
        {
            //pick up a medkit and store it
            medkitStored = true;
        }
        else if(item.tag == "food")
        {
            //pick up and store
            foodStored = true;
        }
        else if(item.tag == "water")
        {
            //pick up and store
            waterStored = true;
        }
        //and then in any case we destroy the object we've picked up
        Destroy(item);
    }
}
