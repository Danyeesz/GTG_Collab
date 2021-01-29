﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreFaith : MonoBehaviour
{

    public Insp_Slider InspBar;



    public  void Restore()
    {
        FollowerController [] followerControllers= transform.GetComponentsInChildren<FollowerController>();

        if (InspBar.slider.value >= 0.25f && InspBar.slider.value < 0.5f)
        {
            foreach (FollowerController follower in followerControllers)
            {
                follower.Restore(4f);
                InspBar.SetInsp(0f);
            }

        }
        else if (InspBar.slider.value >= 0.5f && InspBar.slider.value < 0.75f)
        {
            foreach (FollowerController follower in followerControllers)
            {
                follower.Restore(8f);
                InspBar.SetInsp(0f);
            }

        }
        else if (InspBar.slider.value >= 0.75f && InspBar.slider.value <= 1f)
        {
            foreach (FollowerController follower in followerControllers)
            {
                follower.Restore(12f);
                InspBar.SetInsp(0f);
            }

        }


    }
    
}