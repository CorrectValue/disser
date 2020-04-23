using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionMaker : MonoBehaviour
{
    //this class serves as a decision-maker for an agent basing on his current state
    //every state of an agent has its priority to resolve
    //urge to drink is more important than urge to eat
    //but if an agent has low HP, we first need to check his sat/hyd states
    //because if he has low HP and is hungry, his hunger will kill him much faster than he will find a medkit

    //we will store all the states here just to make it simpler
    bool hungry, thirsty, dying;

    // Update is called once per frame
    void Update()
    {
        //get a reference to the state controller class
        var stateController = gameObject.GetComponent<agentStateController>();
        //check states
        hungry = stateController.isHungry();
        thirsty = stateController.isThirsty();
        dying = stateController.isDying();
    }

    private int makeDecision()
    {
        //returns the final decision
        //0 - collect points
        //1 - go find food
        //2 - go find water
        //3 - go find a medkit
        
        //returning value will be overwritten every time a new condition works
        int returnValue;

        returnValue = 0; //until any of the conditions work, agent will be simply collecting points

        if(dying)
        {
            //need to find a medkit
            returnValue = 3;
        }
        if(hungry)
        {
            //need to find food to eat because even on low hp hunger is much more dangerous
            returnValue = 1;
        }
        if(thirsty)
        {
            //need to find water asap because thirst kills faster than hunger
            returnValue = 2;
        }

        //return decision
        return returnValue;
    }
}
