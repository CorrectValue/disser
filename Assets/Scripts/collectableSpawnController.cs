using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableSpawnController : MonoBehaviour
{

    private int commonObjectsCount;     //count of objects with value 1
    private int uncommonObjectsCount;   //count of objects with value 3
    private int rareObjectsCount;       //count of objects with value 5
    private int legendaryObjectsCount;  //count of objects with value 10 (not more than 1)

    private float commonNextSpawnTime;
    private float uncommonNextSpawnTime;
    private float rareNextSpawnTime;
    private float legendaryNextSpawnTime;

    public int commonObjectsThreshold;//maximum number of objects of given type
    public int uncommonObjectsThreshold;
    public int rareObjectsThreshold;
    public int legendaryObjectsThreshold;

    public float commonSpawnDelay;
    public float uncommonSpawnDelay;
    public float rareSpawnDelay;
    public float legendarySpawnDelay;
    public GameObject prefab;

    private Vector3 pos;  //position to spawn to
    private Quaternion rot;  //rotation to spawn

    // Start is called before the first frame update
    void Start()
    {
        //fill the arena with all types of objects
        for (int i = 0; i < commonObjectsThreshold; i++)
        {
            Spawn(1, ref commonNextSpawnTime, ref commonObjectsCount, commonSpawnDelay);
        }
        for (int i = 0; i < uncommonObjectsThreshold; i++)
        {
            Spawn(3, ref uncommonNextSpawnTime, ref uncommonObjectsCount, uncommonSpawnDelay);
        }
        for (int i = 0; i < rareObjectsThreshold; i++)
        {
            Spawn(5, ref rareSpawnDelay, ref rareObjectsCount, rareSpawnDelay);
        }
        for (int i = 0; i < legendaryObjectsThreshold; i++)
        {
            Spawn(10, ref legendaryNextSpawnTime, ref legendaryObjectsCount, legendarySpawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //consequently check all types of objects 
        if(shouldSpawn(commonObjectsCount, commonObjectsThreshold, commonSpawnDelay, ref commonNextSpawnTime))
        {
            Spawn(1, ref commonNextSpawnTime, ref commonObjectsCount, commonSpawnDelay);
        }
        if (shouldSpawn(uncommonObjectsCount, uncommonObjectsThreshold, uncommonSpawnDelay, ref uncommonNextSpawnTime))
        {
            Spawn(3, ref uncommonNextSpawnTime, ref uncommonObjectsCount, uncommonSpawnDelay);
        }
        if (shouldSpawn(rareObjectsCount, rareObjectsThreshold, rareSpawnDelay, ref rareNextSpawnTime))
        {
            Spawn(5, ref rareSpawnDelay, ref rareObjectsCount, rareSpawnDelay);
        }
        if (shouldSpawn(legendaryObjectsCount, legendaryObjectsThreshold, legendarySpawnDelay, ref legendaryNextSpawnTime))
        {
            Spawn(10, ref legendaryNextSpawnTime, ref legendaryObjectsCount, legendarySpawnDelay);
        }
    }

    private void Spawn(int value, ref float spawnTime, ref int count, float spawnDelay)
    {
        //generatePosition();
        spawnTime = Time.time + spawnDelay;//
        var obj = Instantiate(prefab, generatePosition(value), rot);
        var scr = obj.GetComponent<collectableController>();
        scr.value = value;
        //increase counter
        count++;
    }

    private Vector3 generatePosition(int value)
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

    private bool shouldSpawn(int count, int threshold, float delay, ref float spawnTime)
    {
        //returns true if a certain type of artifact should spawn
        //check if current number of objects is less than its threshold
        if (count < threshold)
        {
            //check timer
            return Time.time >= spawnTime;
        }
        else
        {
            //total number of objects is equal to the threshold, no need to spawn more
            //update the timer
            spawnTime = Time.time + delay;
            return false;
        }
    }
}
