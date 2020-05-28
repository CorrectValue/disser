using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateAndFloat : MonoBehaviour
{
    float amplitude = 0.005f;
    float speed = 0.75f;
    float t;
    void Start()
    {
        t = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = newPos.y + amplitude * Mathf.Sin(speed * (Time.time - t));
        transform.position = newPos;
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
