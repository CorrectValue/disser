﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    //
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
