using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    public float simulationTime;
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        //set sim time
        //simulationTime = 10; //temporarily
        //find text object to set text into
        timerText = GameObject.Find("timerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //update sim time 
        simulationTime -= Time.deltaTime;
        //before showing time to user, need to convert it into more suitable format

        timerText.text = GenTimeSpanFromSeconds(simulationTime);

        if(simulationTime < 0)
        {
            //time to stop
            simulationTime = 0;
            stopSimulation();
        }
    }

    void stopSimulation()
    {
        //the simulation stops and the next scene must be loaded
        //thus, we need to store all the data to use it later
        GameObject storage = GameObject.Find("storage");
        GameObject contestant1 = GameObject.Find("Contestant1");
        GameObject contestant2 = GameObject.Find("Contestant2");
        var scr = storage.GetComponent<dataStorage2>();
        for(int i = 0; i < 8; i++)
        {
            //load agents into storage lists
            scr.contestant1.Add(contestant1.transform.GetChild(i).gameObject);
            scr.contestant2.Add(contestant2.transform.GetChild(i).gameObject);
        }
        //and switch the scene
        switchScene();
    }

    void switchScene()
    {
        //after everything has been stored, go to the last scene
        SceneManager.LoadScene("Scenes/endMenu");
    }

    static string GenTimeSpanFromSeconds(double seconds)
    {
        //need a method to convert time from float to actual minutes and seconds
        // Create a TimeSpan object and TimeSpan string from 
        // a number of seconds.
        TimeSpan interval = TimeSpan.FromSeconds(seconds);
        string timeInterval = interval.ToString();

        return timeInterval;
        // Pad the end of the TimeSpan string with spaces if it 
        // does not contain milliseconds.
        //int pIndex = timeInterval.IndexOf(':');
        //pIndex = timeInterval.IndexOf('.', pIndex);
        //if (pIndex < 0) timeInterval += "        ";

        //Console.WriteLine("{0,21}{1,26}", seconds, timeInterval);
    }
}
