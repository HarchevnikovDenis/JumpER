﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatforms : MonoBehaviour
{
    private float speed = 3.0f;
    private void Update()
    {
        transform.Translate(-Vector2.right * Time.deltaTime * SpeedManager.speed);    
    }
}