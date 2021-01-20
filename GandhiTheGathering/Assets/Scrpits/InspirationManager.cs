using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspirationManager : MonoBehaviour
{
    public Insp_Slider InspBar;
    int fnumber;
    static public float insp;

    
    void Start()
    {
        fnumber = 0;
    }

  
    void Update()
    {
        
        if (fnumber < FollowerController.f_number)
        {
            insp += 0.1f;
            InspBar.SetInsp(insp);
        }
        fnumber = FollowerController.f_number;
    }

   
}
