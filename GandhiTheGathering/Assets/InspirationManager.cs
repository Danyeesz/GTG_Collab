﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspirationManager : MonoBehaviour
{
    public Insp_Slider InspBar;
    int fnumber;
    public float insp;

    // Start is called before the first frame update
    void Start()
    {
        fnumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fnumber < FollowerController.f_number)
        {
            insp += 0.2f;
            InspBar.SetInsp(insp);
        }
        fnumber = FollowerController.f_number;
    }

    private void Increase(float inspiration)
    {

        

    }
}