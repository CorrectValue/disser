using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agentStatsDisplay : MonoBehaviour
{
    //script is needed to get current agent stats and show them to user
    GameObject text; //reference to the text object
    GameObject testbot; //reference to the instantiated object

    // Start is called before the first frame update
    void Start()
    {
        //get agent reference 
        testbot = GameObject.Find("testBot");
        text = testbot.transform.Find("Text").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //get current stats
        var scr = gameObject.GetComponent<agentStateController>();
        //REFINE ME!
    }
}
