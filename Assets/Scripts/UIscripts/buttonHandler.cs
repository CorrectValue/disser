using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonHandler : MonoBehaviour
{
    private GameObject foodSlider, waterSlider, spawnRateSlider, pointCountSlider, simTimeSlider;
    private GameObject drop1, drop2; //dropdowns to select contestants from
    private GameObject storage;
    private GameObject foodSpawnController;
    private float foodValue, waterValue, pointCountValue, spawnRateValue, simTimeValue;
    private int selected1, selected2;

    void Start()
    {
        //get all the gameobjects first
        //get UI objects to get data from
        foodSlider = GameObject.Find("foodSlider");
        waterSlider = GameObject.Find("waterSlider");
        pointCountSlider = GameObject.Find("pointCountSlider");
        spawnRateSlider = GameObject.Find("spawnRateSlider");
        simTimeSlider = GameObject.Find("simTimeSlider");

        drop1 = GameObject.Find("contestant1Dropdown");
        drop2 = GameObject.Find("contestant2Dropdown");

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

        selected1 = drop1.GetComponent<Dropdown>().value;
        selected2 = drop2.GetComponent<Dropdown>().value;
    }

    private void set()
    {
        //set values into storage
        storage.GetComponent<dataStorageScript>().foodValue = foodValue;
        storage.GetComponent<dataStorageScript>().waterValue = waterValue;
        storage.GetComponent<dataStorageScript>().pointCountValue = pointCountValue;
        storage.GetComponent<dataStorageScript>().spawnRateValue = spawnRateValue;
        storage.GetComponent<dataStorageScript>().simTimeValue = simTimeValue;
        storage.GetComponent<dataStorageScript>().selected1 = selected1;
        storage.GetComponent<dataStorageScript>().selected2 = selected2;
    }

    private void nextScene()
    {
        SceneManager.LoadScene("Scenes/scene");
    }
}
