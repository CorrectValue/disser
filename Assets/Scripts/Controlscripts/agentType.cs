using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentType : MonoBehaviour
{
    //this script defines the type of an agent
    public int type;
    /*0 - clever
    1 - cautious
    2 - balanced
    3 - risky*/
    // Start is called before the first frame update
    void Start()
    {
        //get renderer component from gameobject
        var renderer = gameObject.GetComponent<Renderer>();
        //define the color of an agent based on its type
        switch(type)
        {
            case 0:
                //clever population - set blue color
                renderer.material.SetColor("_Color", Color.cyan);
                break;
            case 1:
                //cautious population - set green color
                renderer.material.SetColor("_Color", Color.green);
                break;
            case 2:
                //balanced population - set yellow color
                renderer.material.SetColor("_Color", Color.yellow);
                break;
            case 3:
                //risky population - set red color
                renderer.material.SetColor("_Color", Color.red);
                break;
        }
    }
}
