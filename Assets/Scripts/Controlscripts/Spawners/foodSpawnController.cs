using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawnController : MonoBehaviour
{

    private int totalFoodCount;         //a total count of all food items present in the scene
    public int foodCountThreshold;     //a max number of food in the scene
    private float nextSpawnTime;        //next spawn time.
    public float spawnDelay;            //a pause between two consequent spawns

    public GameObject prefab1;
    public GameObject prefab2;

    private GameObject parent; //parent object for food to clean up the scene

    private Vector3 pos;  //position to spawn to
    private Quaternion rot;  //rotation to spawn

    private static int id; //global id

    // Start is called before the first frame update
    void Start()
    {
        //get food parent obj
        parent = GameObject.Find("Food");
        //fill the arena before anyone can grab items
        for(int i = 0; i < foodCountThreshold; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get real number of food presented in the scene 
        totalFoodCount = GameObject.FindGameObjectsWithTag("food").Length;
        if (shouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime= Time.time + spawnDelay;//
        GameObject obj;
        int randNum = Random.Range(0, 2);
        if(randNum == 1)
            obj = Instantiate(prefab1, generatePosition(), rot);
        else
            obj = Instantiate(prefab2, generatePosition(), rot);
        //set tag
        obj.gameObject.tag = "food";
        //set id
        var scr2 = obj.GetComponent<itemController>();
        scr2.id = id;
        id++;
        //put into parent object
        obj.transform.parent = parent.transform;
        //increase counter
        totalFoodCount++;
    }
    
    private Vector3 generatePosition()
    {
        //generates position to spawn to
        float newx, newy, newz;
        //generate x, y and z accordingly to the value set by previous methods
        newx = Random.Range(-139, 139);
        newy = 2;
        newz = Random.Range(-139, 139);

        return new Vector3(newx, newy, newz);
    }

    private bool shouldSpawn()
    {
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
