using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreFaith : MonoBehaviour
{


    

    public void Restore()
    {
        foreach (Transform child in transform)
        {

            GetComponentInChildren<FollowerController>().Restore();

        }
    }
    
}
