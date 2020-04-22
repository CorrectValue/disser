using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentSpawnController : MonoBehaviour
{
    //this script serves to execute initial spawn of both population of agents
    private int populationCount = 8;
    public int selected1, selected2;
    public GameObject contestant1, contestant2; //by now, we have two different prefabs, but idk if it's necessary
    private Quaternion rot; //rotation to spawn
    // Start is called before the first frame update
    void Start()
    {
        //spawn all the agents of selected population  
        for(int i = 0; i < populationCount; i++)
        {
            //spawn agent of the 1st population
            var obj = Instantiate(contestant1, generatePosition(), rot);
            obj.GetComponent<agentType>().type = selected1;
            //spawn agent of the 2nd population
            var obj2 = Instantiate(contestant2, generatePosition(), rot);
            obj2.GetComponent<agentType>().type = selected2;
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
