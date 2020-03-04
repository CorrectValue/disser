using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawnController : MonoBehaviour
{

    private int totalFoodCount;         //a total count of all food items present in the scene
    private int foodCountThreshold;     //a max number of food in the scene
    private float nextSpawnTime;        //next spawn time.
    public float spawnDelay;            //a pause between two consequent spawns

    public GameObject prefab1;
    public GameObject prefab2;

    private Vector3 pos;  //position to spawn to
    private Quaternion rot;  //rotation to spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime= Time.time + spawnDelay;//
        var obj;
        int randNum = Random.Range(0, 1);
        if(randNum)
            obj = Instantiate(prefab1, generatePosition(), rot);
        else
            obj = Instantiate(prefab2, generatePosition(), rot);
        //increase counter
        totalFoodCount++;
    }
    
    private Vector3 generatePosition()
    {
        //generates position to spawn to
        float newx, newy, newz;
        //generate x, y and z accordingly to the value set by previous methods
        //TEMPORARILY
        newx = Random.Range(0, 10);
        newy = 2;
        newz = Random.Range(0, 10);

        return new Vector3(newx, newy, newz);
    }

    private bool shouldSpawn()
    {
        //returns true if a certain type of artifact should spawn
        //common artifact
        //check if current number of objects is less than its threshold
        if (totalFoodCount < foodCountThreshold)
        {
            //check timer
            return Time.time >= nextSpawnTime;
        }
        else
        {
            //total number of objects is equal to the threshold, no need to spawn more
            //update the timer
            nextSpawnTime = Time.time + spawnDelay;
            return false;
        }
    }
}
