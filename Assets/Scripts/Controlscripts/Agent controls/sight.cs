using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class sight : MonoBehaviour {

    //public float viewRadius;
    //public float viewAngle;
    public List<GameObject> objects; //list of all the objects present in the fov


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "food" || other.gameObject.tag == "water" || other.gameObject.tag == "collectable1" || other.gameObject.tag == "collectable3" || 
            other.gameObject.tag == "collectable5" || other.gameObject.tag == "collectable10")
        {
            //add object to list
            objects.Add(other.gameObject);
        }
    }

    Vector3 checkObjectPresenceInFOV(int obj)
    {
        //checks if a desired object is in agent's fov
        switch(obj)
        {
            case 0:
                //food
                foreach(GameObject Object in objects)
                {
                    if(Object.tag == "food")
                    {
                        return Object.transform.position;
                    }
                }
                break;
            case 1:
                //water
                foreach (GameObject Object in objects)
                {
                    if (Object.tag == "water")
                    {
                        return Object.transform.position;
                    }
                }
                break;
            case 2:
                //medkit
                foreach (GameObject Object in objects)
                {
                    if (Object.tag == "medkit")
                    {
                        return Object.transform.position;
                    }
                }
                break;
            case 3:
                //any collectable
                foreach (GameObject Object in objects)
                {
                    if (Object.tag == "collectable1" || Object.tag == "collectable3" ||
            Object.tag == "collectable5" || Object.tag == "collectable10")
                    {
                        return Object.transform.position;
                    }
                }
                break;
        }
        return new Vector3(0, -100, 0); //in case nothing is found, return inconsistent coordinate
    }
}
