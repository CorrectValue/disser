using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clampBars : MonoBehaviour
{

    public Text label;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 labelPos = Camera.main.WorldToScreenPoint(this.transform.position);
        label.transform.position = labelPos;
    }
}
