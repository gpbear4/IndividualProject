﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float outOfBoundsY = -3.0f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= outOfBoundsY)
        {
            Destroy(gameObject);
        }

    }
}
