using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaithBar : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    public void SetFaith(float faith)
    {
        slider.value = faith;
    }

    public void SetMaxFaith(float faith) 
    {

        slider.maxValue = faith;
        slider.value = faith;

    }
}
