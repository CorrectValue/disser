using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentSpawnController : MonoBehaviour
{
    //this script serves to execute initial spawn of both population of agents
    private int populationCount = 8;
    private int globalId = 0;
    public int selected1, selected2;
    public GameObject agent; //agent prefab
    private GameObject population1, population2; //two different populations
    private Quaternion rot; //rotation to spawn
    // Start is called before the first frame update
    void Start()
    {
        //get population objects
        population1 = GameObject.Find("Contestant1");
        population2 = GameObject.Find("Contestant2");
        //spawn all the agents of selected population  
        for (int i = 0; i < populationCount; i++)
        {
            //spawn agent of the 1st population
            var obj = Instantiate(agent, generatePosition(), rot);
            obj.GetComponent<agentType>().type = selected1;
            //set id
            obj.GetComponent<agentController>().id = globalId;
            //set tag
            obj.gameObject.tag = "contestant1";
            //place agents of the 1st population into a parent object
            obj.transform.parent = population1.transform;
            //spawn agent of the 2nd population
            var obj2 = Instantiate(agent, generatePosition(), rot);
            obj2.GetComponent<agentType>().type = selected2;
            //set id
            obj2.GetComponent<agentController>().id = globalId;
            //set tag
            obj2.gameObject.tag = "contestant2";
            //place agents of the 2nd population into a parent object
            obj2.transform.parent = population2.transform;
        }

    }

    //position generator for agent spawning
    private Vector3 generatePosition()
    {
        //need to generate a random position OUTSIDE of the danger zone
        //but for now
        //TEMPORARILY
        //we will spawn agents all over the place
        float x = Random.Range(-139, 139);
        float y = 2;
        float z = Random.Range(-139, 139);

        return new Vector3(x, y, z);
    }
}
