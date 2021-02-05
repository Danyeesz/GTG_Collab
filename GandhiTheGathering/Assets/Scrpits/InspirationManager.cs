using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspirationManager : MonoBehaviour
{
    public Insp_Slider InspBar;
    int fnumber;
    int fnumberold;
    public float insp;
 
    
    void Start()
    {
        fnumber = 0;
        fnumberold = fnumber;
    }

  
    void Update()
    {

        fnumber = GameObject.Find("Followers").transform.childCount;
      
        if (fnumber == (fnumberold+3))
        {
            InspBar.SetInsp(0.3f);
            fnumberold = fnumber;
        }
        if (fnumber == (fnumberold + 5))
        {
            InspBar.SetInsp(0.5f);
            fnumberold = fnumber;
        }
        if (fnumber == (fnumberold + 10))
        {
            InspBar.SetInsp(1.0f);
            fnumberold = fnumber;
        }


    }

   
}
