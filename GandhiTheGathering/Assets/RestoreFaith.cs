using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreFaith : MonoBehaviour
{

    public Insp_Slider InspBar;



    public  void Restore()
    {
        foreach (Transform child in transform)
        {

            
            if (InspBar.slider.value>=0.25f && InspBar.slider.value < 0.5f)
            {
                GetComponentInChildren<FollowerController>().Restore(4f);
                InspBar.SetInsp(0f);
            }
            else if (InspBar.slider.value >= 0.5f && InspBar.slider.value < 0.75f)
            {
                GetComponentInChildren<FollowerController>().Restore(8f);
                InspBar.SetInsp(0f);
            }
            else if (InspBar.slider.value >= 0.75f && InspBar.slider.value <= 1f)
            {
                GetComponentInChildren<FollowerController>().Restore(12f);
                InspBar.SetInsp(0f);
            }
        }
    }
    
}
