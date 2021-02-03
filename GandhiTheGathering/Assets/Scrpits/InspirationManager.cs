using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspirationManager : MonoBehaviour
{
    static public Insp_Slider InspBar;
    int fnumber;
    public float insp;
    static public int CrowdSize;
    
    void Start()
    {
        fnumber = 0;
    }

  
    void Update()
    {
     
        if (CrowdSize == 3)
        {
           
                insp += 0.3f;
                InspBar.SetInsp(insp);
                fnumber = GameObject.Find("Followers").transform.childCount;
            
            
        }
        
        
    }

   
}
