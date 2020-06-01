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

    void OnEnable()
    {
        storage = GameObject.Find("storage");
        int type1, type2;
        Debug.Log("EndScreen");
        type1 = storage.GetComponent<dataStorage2>().contestant1[0].GetComponent<agentType>().type;
        type2 = storage.GetComponent<dataStorage2>().contestant2[0].GetComponent<agentType>().type;

        con1 = GameObject.Find("Canvas/Con1").GetComponent<UnityEngine.UI.Text>();
        con2 = GameObject.Find("Canvas/Con2").GetComponent<UnityEngine.UI.Text>();

        winner = GameObject.Find("Canvas/Winner").GetComponent<UnityEngine.UI.Text>();

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
