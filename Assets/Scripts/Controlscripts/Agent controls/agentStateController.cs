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
    public int points; //sum of points collected by agent

    public int searchTarget; //this is a KOSTYL

    //maximum values 
    private float maxHealth; 
    private float maxSatiety;
    private float maxHydration;

    //flags
    private bool dead;
    private bool hungry;
    private bool dying;
    private bool thirsty;

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
        dead = false;
        //initialize thresholds
        //we have a unified interface which means it's urgent to get the type of the population from a different script
        //here, clever agent acts like a balanced one and has somewhat balanced thresholds
        //cautious agent has higher thresholds which means he will be eating more often "just in case"
        //risky agent has the lowest values - he basically does not care about it
        switch(gameObject.GetComponent<agentType>().type)
        {
            case 0:
                //an agent belongs to the clever population
                satietyThreshold = 30.0f;
                hydrationThreshold = 30.0f;
                break;
            case 1:
                //an agent belongs to the cautious population
                satietyThreshold = 50.0f;
                hydrationThreshold = 60.0f;
                break;
            case 2:
                //an agent belongs to the balanced population
                satietyThreshold = 30.0f;
                hydrationThreshold = 30.0f;
                break;
            case 3:
                //an agent belongs to the risky population
                satietyThreshold = 10.0f;
                hydrationThreshold = 15.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            //recalculate values and check if they are decreased below turning point
            //recaltulate satiety based only on time
            satiety = satiety - Time.deltaTime * 1f; //need to make a better formula
            if (satiety < 0)
                satiety = 0;
            //recalculate hydration based on time - but with different coefficients
            hydration = hydration - Time.deltaTime * 1.2f; //for now
            if (hydration < 0)
                hydration = 0;

            //if the values of satiety and hydration are above their thresholds, restore HP
            if (hydration > hydrationThreshold && satiety > satietyThreshold)
            {
                //restore HP if needed
                if (health < maxHealth)
                {
                    health += Mathf.Sqrt(Mathf.Pow((hydration - hydrationThreshold), 2) + Mathf.Pow((satiety - satietyThreshold), 2));
                    if (health > maxHealth)
                        health = maxHealth;
                }
            }

            //now, check if those values have fallen below the threshold
            //if so, need to reset priorities
            if (satiety < satietyThreshold)
            {
                //the agent is hungry!
                hungry = true;
            }
            else
            {
                hungry = false;
            }

            if (hydration < hydrationThreshold)
            {
                //the agent is thirsty!
                thirsty = true;
            }
            else
            {
                thirsty = false;
            }

            if (health < healthThreshold)
            {
                //the agent is dying!
                dying = true;
            }
            else
            {
                dying = false;
            }

            //check if any of the stats has fallen below zero
            if (health <= 0)
            {
                //whoops... 
                die();
            }
            if (satiety == 0)
            {
                //very hungry, start decreasing health
                health = health - Time.deltaTime * 1.3f; //need to make a better formula
            }
            if (hydration == 0)
            {
                //very thirsty, start decreasing health
                health = health - Time.deltaTime * 1.5f; //need to make a better formula
            }
        }
    }

    void die()
    {
        //if health falls below zero, the agent is dead (or stunned)
        dead = true;
        //need to animate it somehow
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        gameObject.transform.Translate(0.0f, -1.0f, 0.0f);
    }

    public void eat()
    {
        //an agent has found something to eat
        float value = 40.0f;
        satiety += value;
        if (satiety > maxSatiety)
            satiety = maxSatiety;
        var scr = gameObject.GetComponent<itemManager>();
        scr.foodStored = false;
    }

    public void drink()
    {
        //an agent has found something to drink
        float value = 40.0f;
        hydration += value;
        if (hydration > maxHydration)
            hydration = maxHydration;
        //set stored beverage false
        var scr = gameObject.GetComponent<itemManager>();
        scr.waterStored = false;
    }

    public void heal()
    {
        //an agent has found a medkit
        float value = 70.0f;
        health += value;
        if (health > maxHealth)
            health = maxHealth;
        var scr = gameObject.GetComponent<itemManager>();
        scr.medkitStored = false;
    }

    public void earnPoint(int value)
    {
        //an agent has found a collectable object
        points += value;
    }

    public bool isHungry()
    {
        //returns true if an agent is hungry
        return hungry;
    }
    public bool isThirsty()
    {
        //returns true if an agent is thirsty
        return thirsty;
    }
    public bool isDying()
    {
        //returns true if an agent has very low HP
        return dying;
    }
    public bool isDead()
    {
        return dead;
    }
}
