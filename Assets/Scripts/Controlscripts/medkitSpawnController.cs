using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitSpawnController : MonoBehaviour
{
    private int totalMedkitCount;
    public int medkitCountThreshold;
    private float nextSpawnTime;        //next spawn time.
    public float spawnDelay;            //a pause between two consequent spawns

    public GameObject prefab1;
    private Vector3 pos;  //position to spawn to
    private Quaternion rot;  //rotation to spawn

    // Start is called before the first frame update
    void Start()
    {
        //set initial filling of the arena
        for (int i = 0; i < medkitCountThreshold; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        totalMedkitCount = GameObject.FindGameObjectsWithTag("medkit").Length;
        if (shouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;//
        GameObject obj;
        obj = Instantiate(prefab1, generatePosition(), rot);
        //set tag
        obj.gameObject.tag = "medkit";
        //increase counter
        totalMedkitCount++;
    }

    private Vector3 generatePosition()
    {
        //generates position to spawn to
        float newx, newy, newz;
        //generate x, y and z accordingly to the value set by previous methods
        //TEMPORARILY
        newx = Random.Range(-139, 139);
        newy = 2;
        newz = Random.Range(-139, 139);

        return new Vector3(newx, newy, newz);
    }

    private bool shouldSpawn()
    {
        //returns true if a certain type of artifact should spawn
        //common artifact
        //check if current number of objects is less than its threshold
        if (totalMedkitCount < medkitCountThreshold)
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
