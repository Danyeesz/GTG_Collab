using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreFaith : MonoBehaviour
{

    public Insp_Slider InspBar;
    public int quarter;
    public int half;
    public int full;


    public  void Restore()
    {
        FollowerController [] followerControllers= transform.GetComponentsInChildren<FollowerController>();

        if (InspBar.slider.value >= 0.25f && InspBar.slider.value < 0.5f)
        {
            foreach (FollowerController follower in followerControllers)
            {
                if ((follower.CurrentFaith + quarter) > follower.MaxFaith)
                {
                    follower.Restore((follower.MaxFaith - follower.CurrentFaith));
                    
                }
                else
                {
                    follower.Restore(quarter);
                }

                
            }
            InspBar.slider.value = 0f;
        }
        else if (InspBar.slider.value >= 0.5f && InspBar.slider.value < 0.75f)
        {
            foreach (FollowerController follower in followerControllers)
            {
                if ((follower.CurrentFaith + half) > follower.MaxFaith)
                {
                    follower.Restore((follower.MaxFaith - follower.CurrentFaith));
                    
                }
                else
                {
                    follower.Restore(half);
                   

                }
               
            }
            InspBar.slider.value = 0f;
        }
        else if (InspBar.slider.value >= 0.75f && InspBar.slider.value <= 1f)
        {
            foreach (FollowerController follower in followerControllers)
            {
                if ((follower.CurrentFaith + full) > follower.MaxFaith)
                {
                    follower.Restore((follower.MaxFaith - follower.CurrentFaith));
                    
                }
                else
                {
                    follower.Restore(full);
                    

                }
            }
            InspBar.slider.value = 0f;
        }


    }
    
}
