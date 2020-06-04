using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataReader2 : MonoBehaviour
{
    //supposed to read data from datastorage2 into the final scene
    GameObject storage;
    Text con1, con2;
    Text winner;
    int points1, points2;
    public GameObject panel;
    GameObject parent;
    Quaternion rot;

    void OnEnable()
    {
        //set cursor visible
        Cursor.visible = true;

        storage = GameObject.Find("storage");
        parent = GameObject.Find("Cvs");
        int type1, type2;
        Debug.Log("EndScreen");
        type1 = storage.GetComponent<dataStorage2>().contestant1[0].GetComponent<agentType>().type;
        type2 = storage.GetComponent<dataStorage2>().contestant2[0].GetComponent<agentType>().type;

        con1 = GameObject.Find("Cvs/Con1").GetComponent<UnityEngine.UI.Text>();
        con2 = GameObject.Find("Cvs/Con2").GetComponent<UnityEngine.UI.Text>();

        winner = GameObject.Find("Cvs/Winner").GetComponent<UnityEngine.UI.Text>();

        switch (type1)
        {
            case 0:
                con1.text = "Contestant1: clever";
                break;
            case 1:
                con1.text = "Contestant1: cautious";
                break;
            case 2:
                con1.text = "Contestant1: balanced";
                break;
            case 3:
                con1.text = "Contestant1: risky";
                break;
        }
        switch (type2)
        {
            case 0:
                con2.text = "Contestant2: clever";
                break;
            case 1:
                con2.text = "Contestant2: cautious";
                break;
            case 2:
                con2.text = "Contestant2: balanced";
                break;
            case 3:
                con2.text = "Contestant2: risky";
                break;
        }
        //count contestants' points
        countPoints();
        //select winner
        winner.text = getWinner();
        //fill the table with all the agents
        var scr = storage.GetComponent<dataStorage2>();
        for (int i = 0; i < 8; i++)
        {
            //instantiate panels
            Debug.Log("canvas is");
            var obj = Instantiate(panel, new Vector3(158, 340 - 35 * i, 0), rot,  parent.transform);
            obj.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Agent #" + scr.contestant1[i].GetComponent<agentController>().id 
                + " Time alive: " + scr.contestant1[i].GetComponent<agentStateController>().timeAlive +
                "\n" + "Points: " + scr.contestant1[i].GetComponent<agentStateController>().points +
                " Health: " + scr.contestant1[i].GetComponent<agentStateController>().health;
            var obj2 = Instantiate(panel, new Vector3(620, 340 - 35 * i, 0), rot, parent.transform);
            obj2.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Agent #" + scr.contestant2[i].GetComponent<agentController>().id
               + " Time alive: " + scr.contestant2[i].GetComponent<agentStateController>().timeAlive +
               "\n" + "Points: " + scr.contestant2[i].GetComponent<agentStateController>().points +
               " Health: " + scr.contestant2[i].GetComponent<agentStateController>().health;
        }
        //destroy agents
        destroyAgents();
    }

    void countPoints()
    {
        //decides who has won the battle
        var scr = storage.GetComponent<dataStorage2>();
        points1 = 0;
        points2 = 0; //points of the 1st and the 2nd population
        for(int i = 0; i < 8; i++)
        {
            //sum all the points
            points1 += scr.contestant1[i].GetComponent<agentStateController>().points;
            points2 += scr.contestant2[i].GetComponent<agentStateController>().points;
        }

    }

    string getWinner()
    {
        if(points1 > points2)
        {
            return "Winner is contestant 1"; //contestant1 wins
        }
        else if(points1 < points2)
        {
            return "Winner is contestant 2"; //con2 wins
        }
        else //if(points1 == points2)
        {
            return "Battle result: draw"; //draw
        }
    }

    void destroyAgents()
    {
        //destroys agents from prev scene
        Destroy(GameObject.Find("Contestant1"));
        Destroy(GameObject.Find("Contestant2"));
    }
}
