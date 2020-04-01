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
        //set values into storage
        storage.GetComponent<dataStorageScript>().foodValue = foodValue;
        storage.GetComponent<dataStorageScript>().waterValue = waterValue;
        storage.GetComponent<dataStorageScript>().pointCountValue = pointCountValue;
        storage.GetComponent<dataStorageScript>().spawnRateValue = spawnRateValue;
        storage.GetComponent<dataStorageScript>().simTimeValue = simTimeValue;
    }

    private void nextScene()
    {
        DontDestroyOnLoad(storage); //save this object in memory to read data in the next scene
        SceneManager.LoadScene("Scenes/scene");
    }
}
