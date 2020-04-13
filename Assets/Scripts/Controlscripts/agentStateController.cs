using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentStateController : MonoBehaviour
{
    //need to have global ID for agents
    public static int globalId;
    public int id;
    //this script is needed to maintain control of all of the agent's stats
    //such as health, satiety and hydration
    public float health;   //health points of an agent: zero means death
    public float satiety;  //means how hungry an agent is: zero means hungry => slowly decreasing HP
    public float hydration;//means how hydrated an agent is: zero means thirsty => decreasing HP
    public float points; //sum of points collected by agent

    //thresholds for values above - different for different populations
    private float satietyThreshold;
    private float hydrationThreshold;
    private float healthThreshold;

    // Start is called before the first frame update
    void Start()
    {
        //initialize values
        health = 100.0f;
        satiety = 70.0f;
        hydration = 70.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //recalculate values and check if they are decreased below turning point
        //recaltulate satiety based only on time
        satiety = satiety - Time.deltaTime * 1f; //need to make a better formula
        //recalculate hydration based on time - but with different coefficients
        hydration = hydration - Time.deltaTime * 1.2f; //for now

        //now, check if those values have fallen below the threshold
        //if so, need to reset priorities
        if (satiety < satietyThreshold)
        {
            //the agent is hungry!
        }
        if (hydration < hydrationThreshold)
        {
            //the agent is thirsty!
        }
        if (health < healthThreshold)
        {
            //the agent is dying!
        }
        //check if any of the stats has fallen below zero
        if (health < 0)
        {
            //whoops... 
            die();
        }
        if(satiety < 0)
        {
            //very hungry, start decreasing health
            health = health - Time.deltaTime * 1.3f; //need to make a better formula
        }
        if(hydration < 0)
        {
            //very thirsty, start decreasing health
            health = health - Time.deltaTime * 1.5f; //need to make a better formula
        }
    }

    void die()
    {
        //if health falls below zero, the agent is dead (or stunned)
    }
}
