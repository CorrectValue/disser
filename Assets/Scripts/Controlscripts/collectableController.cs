using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableController : MonoBehaviour
{

    private float size;     //size of an object is connected to its value
    public int value;    //the bigger the value the bigger the object
    private float baseSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        //set object appearance corresponding to its value
        size = baseSize * Mathf.Sqrt(value);
        transform.localScale *= size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
