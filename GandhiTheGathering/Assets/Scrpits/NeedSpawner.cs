using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedSpawner : MonoBehaviour
{
    public float maxTime = 20;
    public float minTime = 5;
    private float time;
    private float spawnTime;

    int randm;

    public Slider FoodVsEqu;
    public Slider HinduVsReli;
    public Slider BritainVsIndia;

    void Start()
    {
        SetRandomTime();
        time = minTime;
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;


        FoodVsEqu = GameObject.FindGameObjectWithTag("FvsE").GetComponent<Slider>();
        HinduVsReli = GameObject.FindGameObjectWithTag("HvsR").GetComponent<Slider>();
        BritainVsIndia = GameObject.FindGameObjectWithTag("BvsI").GetComponent<Slider>();
        FoodVsEqu.value = 0.5f;
        HinduVsReli.value = 0.5f;
        BritainVsIndia.value = 0.5f;
       
       
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnButton();
            SetRandomTime();
        }

    }

    void SpawnButton()
    {
        time = 0;
        randm = Random.Range(0, 5);
        transform.GetChild(randm).gameObject.SetActive(true);

    }
    
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    public void ButtonClicked()
    {
        SetNeeds(0.1f);
        transform.GetChild(randm).gameObject.SetActive(false);
    }



    private void Update()
    {
       
    }
    
    public void SetNeeds(float need)
    {
        if (randm==0)
        {
            FoodVsEqu.value -= need;
        }
        else if (randm == 1)
        {
            FoodVsEqu.value += need;
        }
        else if (randm == 3)
        {
            BritainVsIndia.value -= need;
        }
        else if(randm == 4)
        {
            BritainVsIndia.value += need;
        }
        else if (randm == 5)
        {
            HinduVsReli.value += need;
        }
        else if (randm == 6)
        {
            HinduVsReli.value -= need;
        }
        
       
    }

}
