using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    public float simulationTime; 

    // Start is called before the first frame update
    void Start()
    {
        //set sim time
        simulationTime = 10; //temporarily
    }

    // Update is called once per frame
    void Update()
    {
        //update sim time 
        simulationTime -= Time.deltaTime;

        if(simulationTime < 0)
        {
            //time to stop
            stopSimulation();
        }
    }

    void stopSimulation()
    {
        //the simulation stops and the next scene must be loaded
        //thus, we need to store all the data to use it later
    }

    void switchScene()
    {
        //after everything has been stored, go to the last scene
        SceneManager.LoadScene("Scenes/endMenu");
    }
}
