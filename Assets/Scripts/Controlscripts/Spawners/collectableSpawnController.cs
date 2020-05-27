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

    private GameObject col1, col3, col5, col10; //parent objects

    private Vector3 pos;  //position to spawn to
    private Quaternion rot;  //rotation to spawn

    private static int id; //id to give a new object

    // Start is called before the first frame update
    void Start()
    {
        //get parent objects refs
        col1 = GameObject.Find("Coll1");
        col3 = GameObject.Find("Coll3");
        col5 = GameObject.Find("Coll5");
        col10 = GameObject.Find("Coll10");
        //fill the arena with all types of objects
        for (int i = 0; i < commonObjectsThreshold; i++)
        {
            Spawn(1, ref commonNextSpawnTime, ref commonObjectsCount, commonSpawnDelay, col1);
        }
        for (int i = 0; i < uncommonObjectsThreshold; i++)
        {
            Spawn(3, ref uncommonNextSpawnTime, ref uncommonObjectsCount, uncommonSpawnDelay, col3);
        }
        for (int i = 0; i < rareObjectsThreshold; i++)
        {
            Spawn(5, ref rareSpawnDelay, ref rareObjectsCount, rareSpawnDelay, col5);
        }
        for (int i = 0; i < legendaryObjectsThreshold; i++)
        {
            Spawn(10, ref legendaryNextSpawnTime, ref legendaryObjectsCount, legendarySpawnDelay, col10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check real numbers of objects present in the scene
        commonObjectsCount = GameObject.FindGameObjectsWithTag("collectable1").Length;
        uncommonObjectsCount = GameObject.FindGameObjectsWithTag("collectable3").Length;
        rareObjectsCount = GameObject.FindGameObjectsWithTag("collectable5").Length;
        legendaryObjectsCount = GameObject.FindGameObjectsWithTag("collectable10").Length;
        //consequently check all types of objects 
        if (shouldSpawn(commonObjectsCount, commonObjectsThreshold, commonSpawnDelay, ref commonNextSpawnTime))
        {
            Spawn(1, ref commonNextSpawnTime, ref commonObjectsCount, commonSpawnDelay, col1);
        }
        if (shouldSpawn(uncommonObjectsCount, uncommonObjectsThreshold, uncommonSpawnDelay, ref uncommonNextSpawnTime))
        {
            Spawn(3, ref uncommonNextSpawnTime, ref uncommonObjectsCount, uncommonSpawnDelay, col3);
        }
        if (shouldSpawn(rareObjectsCount, rareObjectsThreshold, rareSpawnDelay, ref rareNextSpawnTime))
        {
            Spawn(5, ref rareSpawnDelay, ref rareObjectsCount, rareSpawnDelay, col5);
        }
        if (shouldSpawn(legendaryObjectsCount, legendaryObjectsThreshold, legendarySpawnDelay, ref legendaryNextSpawnTime))
        {
            Spawn(10, ref legendaryNextSpawnTime, ref legendaryObjectsCount, legendarySpawnDelay, col10);
        }
    }

    private void Spawn(int value, ref float spawnTime, ref int count, float spawnDelay, GameObject par)
    {
        //generatePosition();
        spawnTime = Time.time + spawnDelay;//
        var obj = Instantiate(prefab, generatePosition(value), rot);
        //set tag
        obj.gameObject.tag = "collectable" + value.ToString();
        var scr = obj.GetComponent<collectableController>();
        var scr2 = obj.GetComponent<itemController>();
        scr.value = value;
        scr2.id = id;
        id++;
        //put object into parent
        obj.transform.parent = par.transform;
        //increase counter
        count++;
    }

    private Vector3 generatePosition(int value)
    {
        //generates position to spawn to
        float newx, newy, newz;
        //generate x, y and z accordingly to the value set by previous methods

        switch(value)
        {
            case 1:
                //common objects can be found basically everywhere
                newx = Random.Range(-139, 139);
                newz = Random.Range(-139, 139);
                break;
            case 3:
                //uncommon objects can be found rarer but still almost in any part of arena
                newx = Random.Range(-100, 100);
                newz = Random.Range(-100, 100);
                break;
            case 5:
                //rare objects lie closer and closer to the center
                newx = Random.Range(-50, 50);
                newz = Random.Range(-50, 50);
                break;
            case 10:
                //legendary object must lie closest to the center
                newx = Random.Range(-5, 5);
                newz = Random.Range(-5, 5);
                break;
            default:
                newx = 0;
                newz = 0;
                break;
        }

        newy = 2;

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
