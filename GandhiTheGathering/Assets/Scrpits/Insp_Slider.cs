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
    public void SetInsp(float faith)
    {
        slider.value = faith;
    }

    public void SetMaxInsp(float insp)
    {

        slider.maxValue = insp;
        slider.value = insp;

    }
}
