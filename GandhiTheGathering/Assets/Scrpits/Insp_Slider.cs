using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insp_Slider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    private void Start()
    {
        slider.value = 0;
    }
    // Start is called before the first frame update
    public void SetInsp(float insp)
    {
        if (slider.value + insp > slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
        else
        {
            slider.value += insp;
        }
        
    }

    public void SetMaxInsp(float insp)
    {

        slider.maxValue = insp;
       

    }
}
