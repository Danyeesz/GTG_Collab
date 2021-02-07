using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdManager : MonoBehaviour
{

    public Insp_Slider InspBar;
    public bool CrowdEmpty = false;
    public bool InspInc = false;
   
    void Start()
    {

        InspBar = GameObject.FindGameObjectWithTag("Insp_Slider").GetComponent<Insp_Slider>();
        
        
    }


    void Update()
    {
        if (transform.name == "CrowdOfThree(Clone)")
        {
            if (InspInc == false)
            {
                if (transform.childCount == 1)
                {
                    CrowdEmpty = true;
                    if (CrowdEmpty == true)
                    {
                        InspBar.SetInsp(0.3f);
                        InspInc = true;
                    }

                }

            }
        }
        else if (transform.name == "CrowdOfFive(Clone)")
        {
            if (InspInc == false)
            {
                if (transform.childCount == 1)
                {
                    CrowdEmpty = true;
                    if (CrowdEmpty == true)
                    {
                        InspBar.SetInsp(0.5f);
                        InspInc = true;
                    }

                }

            }
        }
       


        
    }
}
