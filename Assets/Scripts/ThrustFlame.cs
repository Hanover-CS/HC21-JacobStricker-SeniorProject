﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustFlame : MonoBehaviour
{
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        //ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("joy1"))
        {
        ps.Play();
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetButtonUp("joy1"))
        {
        ps.Stop();
        }   
    }
}