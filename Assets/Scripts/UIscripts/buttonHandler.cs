using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonHandler : MonoBehaviour
{
    private GameObject foodSlider, waterSlider, spawnRateSlider, pointCountSlider, simTimeSlider;
    //  private GameObject spawner, controller;
    private GameObject storage;
    private GameObject foodSpawnController;
    private float foodValue, waterValue, pointCountValue, spawnRateValue, simTimeValue;

    void Start()
    {
        //get all the gameobjects first
        //get UI objects to get data from
        foodSlider = GameObject.Find("foodSlider");
        waterSlider = GameObject.Find("waterSlider");
        pointCountSlider = GameObject.Find("pointCountSlider");
        spawnRateSlider = GameObject.Find("spawnRateSlider");
        simTimeSlider = GameObject.Find("simTimeSlider");

        //get in-game objects to set data
        //until the scene is loaded, these objects do not exist!
        //придумай что-нибудь новое
        //for now, data will be stored in the storage unit 
        // spawner = GameObject.Find("Spawner");
        //  controller = GameObject.Find("ControlObject");
        storage = GameObject.Find("DataStorage");
    }

    public void handle()
    {
        //toggle the necessary methods
        get();
        set();
        //switch scene
        nextScene();
    }

    private void get()
    {
        //get data from inputs
        foodValue = foodSlider.GetComponent<Slider>().value;
        waterValue = waterSlider.GetComponent<Slider>().value;
        pointCountValue = pointCountSlider.GetComponent<Slider>().value;
        spawnRateValue = spawnRateSlider.GetComponent<Slider>().value;
        simTimeValue = simTimeSlider.GetComponent<Slider>().value;
    }

    private void set()
    {
        //sets all the parameters from fields of input
        //set food and water spawn thresholds
        //spawner.GetComponent<foodSpawnController>().foodCountThreshold = (int)foodValue;
        //spawner.GetComponent<waterSpawnController>().waterCountThreshold = (int)waterValue;
        ////set points spawn thresholds
        //spawner.GetComponent<collectableSpawnController>().legendaryObjectsThreshold = (int)(pointCountValue / 10);
        //spawner.GetComponent<collectableSpawnController>().rareObjectsThreshold = (int)(pointCountValue / 5);
        //spawner.GetComponent<collectableSpawnController>().uncommonObjectsThreshold = (int)(pointCountValue * 0.3f);
        //spawner.GetComponent<collectableSpawnController>().commonObjectsThreshold = (int)(pointCountValue - pointCountValue / 10 - pointCountValue / 5 - pointCountValue * 0.3f);
        ////set spawn rate 
        //spawner.GetComponent<foodSpawnController>().spawnDelay /= (int)spawnRateValue;
        //spawner.GetComponent<waterSpawnController>().spawnDelay /= (int)spawnRateValue;
        //spawner.GetComponent<collectableSpawnController>().commonSpawnDelay /= (int)spawnRateValue;
        //spawner.GetComponent<collectableSpawnController>().uncommonSpawnDelay /= (int)spawnRateValue;
        //spawner.GetComponent<collectableSpawnController>().rareSpawnDelay /= (int)spawnRateValue;
        //spawner.GetComponent<collectableSpawnController>().legendarySpawnDelay /= (int)spawnRateValue;
        //spawner.GetComponent<medkitSpawnController>().spawnDelay /= (int)spawnRateValue;
        ////set simulation time
        //controller.GetComponent<timer>().simulationTime = simTimeValue;

        //set values into storage
        storage.GetComponent<dataStorageScript>().foodValue = foodValue;
        //storage.GetComponent<dataStorageScript>().setFoodValue(foodValue);
        //storage.GetComponent<dataStorageScript>().setWaterValue(waterValue);
        //storage.GetComponent<dataStorageScript>().setPointCountValue(pointCountValue);
        //storage.GetComponent<dataStorageScript>().setSpawnRateValue(spawnRateValue);
        //storage.GetComponent<dataStorageScript>().setSimTimeValue(simTimeValue);

    }

    private void nextScene()
    {
        SceneManager.LoadScene("Scenes/scene");
    }
}
