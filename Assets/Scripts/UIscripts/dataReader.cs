﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataReader : MonoBehaviour
{
    private GameObject storage, spawner, controller;
    private float foodValue, waterValue, spawnRateValue, simTimeValue, pointCountValue;
    private int selected1, selected2;
    // Start is called before the first frame update
    void OnEnable()
    {
        //make references to necessary objects
        storage = GameObject.Find("DataStorage");
        spawner = GameObject.Find("Spawner");
        controller = GameObject.Find("ControlObject");
        //read data from data storage
        foodValue = storage.GetComponent<dataStorageScript>().foodValue;
        waterValue = storage.GetComponent<dataStorageScript>().waterValue;
        spawnRateValue = storage.GetComponent<dataStorageScript>().spawnRateValue;
        simTimeValue = storage.GetComponent<dataStorageScript>().simTimeValue;
        pointCountValue = storage.GetComponent<dataStorageScript>().pointCountValue;
        selected1 = storage.GetComponent<dataStorageScript>().selected1;
        selected2 = storage.GetComponent<dataStorageScript>().selected2;

        //INCONSISTENT DATA INITIALIZER
        //FOR TEST PURPOSES
        //spawnRateValue = 10;
        //simTimeValue = 10;
        //foodValue = 1000;
        //waterValue = 1000;
        //pointCountValue = 10000;
        

        //set values where they belong
        //set food and water spawn thresholds
        spawner.GetComponent<foodSpawnController>().foodCountThreshold = (int)foodValue;
        spawner.GetComponent<waterSpawnController>().waterCountThreshold = (int)waterValue;
        //set points spawn thresholds
        spawner.GetComponent<collectableSpawnController>().legendaryObjectsThreshold = (int)(pointCountValue / 10);
        spawner.GetComponent<collectableSpawnController>().rareObjectsThreshold = (int)(pointCountValue / 5);
        spawner.GetComponent<collectableSpawnController>().uncommonObjectsThreshold = (int)(pointCountValue * 0.3f);
        spawner.GetComponent<collectableSpawnController>().commonObjectsThreshold = (int)(pointCountValue - pointCountValue / 10 - pointCountValue / 5 - pointCountValue * 0.3f);
        //set spawn rate 
        spawner.GetComponent<foodSpawnController>().spawnDelay /= (int)spawnRateValue;
        spawner.GetComponent<waterSpawnController>().spawnDelay /= (int)spawnRateValue;
        spawner.GetComponent<collectableSpawnController>().commonSpawnDelay /= (int)spawnRateValue;
        spawner.GetComponent<collectableSpawnController>().uncommonSpawnDelay /= (int)spawnRateValue;
        spawner.GetComponent<collectableSpawnController>().rareSpawnDelay /= (int)spawnRateValue;
        spawner.GetComponent<collectableSpawnController>().legendarySpawnDelay /= (int)spawnRateValue;
        spawner.GetComponent<medkitSpawnController>().spawnDelay /= (int)spawnRateValue;
        //set simulation time
        controller.GetComponent<timer>().simulationTime = simTimeValue * 60; //converting minutes to seconds
        //controller.GetComponent<timer>().simulationTime = 1;
        //set populations to spawn
        spawner.GetComponent<agentSpawnController>().selected1 = selected1;
        spawner.GetComponent<agentSpawnController>().selected2 = selected2;
    }

}
