using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonHandler : MonoBehaviour
{
    private GameObject foodSlider, waterSlider, spawnRateSlider, pointCountSlider, simTimeSlider;
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

        //for now, data will be stored in the storage unit 
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
        SceneManager.LoadScene("Scenes/scene");
    }
}
