using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{
    public List<GameObject> objects; //list of all the objects present in the fov
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food" || other.gameObject.tag == "water" || other.gameObject.tag == "collectable1" || other.gameObject.tag == "collectable3" ||
            other.gameObject.tag == "collectable5" || other.gameObject.tag == "collectable10")
        {
            //add object to list
            objects.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //remove an object from the list
        //first find this object in the list
        int index; //index of an object to destroy
        for(int i = 0; i < objects.Count; i++)
        {
            if(objects[i] == null || (objects[i].gameObject.tag == other.gameObject.tag && 
                objects[i].GetComponent<itemController>().id == other.gameObject.GetComponent<itemController>().id))
            {
                objects.RemoveAt(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject checkObjectPresenceInFOV(int obj)
    {
        //checks if a desired object is in agent's fov
        
        switch (obj)
        {
            case 0:
                //food
                foreach (GameObject Object in objects)
                {
                    if (Object != null && Object.tag == "food")
                    {
                        return Object;
                    }
                }
                break;
            case 1:
                //water
                foreach (GameObject Object in objects)
                {
                    if (Object != null && Object.tag == "water")
                    {
                        Debug.Log("I WANT WATERRRR");
                        return Object;
                    }
                }
                break;
            case 2:
                //medkit
                foreach (GameObject Object in objects)
                {
                    if (Object != null && Object.tag == "medkit")
                    {
                        return Object;
                    }
                }
                break;
            case 3:
                //any collectable
                foreach (GameObject Object in objects) 
                {
                    if (Object != null)
                    {
                        if (Object.tag == "collectable1" || Object.tag == "collectable3" ||
                Object.tag == "collectable5" || Object.tag == "collectable10")
                        {
                            return Object;
                        }
                    }
                }
                break;
        }
        return null; //in case nothing is found, return inconsistent coordinate
    }
}
