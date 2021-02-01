using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Needs : MonoBehaviour
{

    public Slider FoodVsEqu;
    public Slider HinduVsReli;
    public Slider BritainVsIndia;

    // Start is called before the first frame update
    void Start()
    {
        FoodVsEqu.value = 0.5f;
        HinduVsReli.value = 0.5f;
        BritainVsIndia.value = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.Find("Followers").transform.childCount); 
    }
}
