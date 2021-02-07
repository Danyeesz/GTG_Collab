using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalMat : MonoBehaviour
{

    public Material[] omats;
    void Start()
    {
        omats = transform.GetComponent<Renderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
