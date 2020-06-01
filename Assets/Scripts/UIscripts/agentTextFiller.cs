using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agentTextFiller : MonoBehaviour
{
    //this script fills text objects above agents' heads

    public Text Txt;

    // Start is called before the first frame update
    void Start()
    {
        var scr = gameObject.GetComponent<agentStateController>();
        Txt.text = "Agent#" + gameObject.GetComponent<agentController>().id + "\n" +
            "HP = " + scr.health.ToString("0.00") + "\n" +
            "Sat = " + scr.satiety.ToString("0.00") + "\n" +
            "Hyd = " + scr.hydration.ToString("0.00") + "\n" +
            "Pts = " + scr.points;
    }

    // Update is called once per frame
    void Update()
    {
        var scr = gameObject.GetComponent<agentStateController>();
        Txt.text = "Agent#" + gameObject.GetComponent<agentController>().id + "\n" +
            "HP = " + scr.health.ToString("0.00") + "\n" +
            "Sat = " + scr.satiety.ToString("0.00") + "\n" +
            "Hyd = " + scr.hydration.ToString("0.00") + "\n" +
            "Pts = " + scr.points;
    }
}
