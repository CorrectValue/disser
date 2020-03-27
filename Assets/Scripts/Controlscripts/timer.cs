using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //как-нибудь в другой раз.
        }
    }
}
