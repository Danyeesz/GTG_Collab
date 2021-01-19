using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Needs : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Slider FoodVsEqu;
    public Slider HinduVsReli;
    public Slider BritainVsIndia;

    private void Start()
    {
        FoodVsEqu.value = 0.5f;
        HinduVsReli.value = 0.5f;
        BritainVsIndia.value = 0.5f;
    }
    // Start is called before the first frame update
    public void SetNeeds(float need)
    {
        FoodVsEqu.value = need;
        HinduVsReli.value = need;
    }

    public void SetMaxInsp(float insp)
    {

        HinduVsReli.maxValue = insp;
        HinduVsReli.value = insp;

    }
}
