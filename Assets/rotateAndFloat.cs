using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateAndFloat : MonoBehaviour
{
    float amplitude = 0.025f;
    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = newPos.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = newPos;
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
