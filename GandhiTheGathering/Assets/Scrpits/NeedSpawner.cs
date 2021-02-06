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
    public float needtime;
    public float timer;
    int randm;

    public Image t_image;

    GameObject FollowerHolder;

    public Slider FoodVsEqu;
    public Slider HinduVsReli;
    public Slider BritainVsIndia;

    void Start()
    {
        SetRandomTime();
        time = minTime;
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
        timer = needtime;
        


        FollowerHolder = GameObject.Find("Followers");

        FoodVsEqu = GameObject.FindGameObjectWithTag("FvsE").GetComponent<Slider>();
        HinduVsReli = GameObject.FindGameObjectWithTag("HvsR").GetComponent<Slider>();
        BritainVsIndia = GameObject.FindGameObjectWithTag("BvsI").GetComponent<Slider>();
        


    }


    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            StartCoroutine(SpawnButton());
            SetRandomTime();
        }
       
        if (BritainVsIndia.value == BritainVsIndia.maxValue || BritainVsIndia.value == BritainVsIndia.minValue)
        {
            int randomF = Random.Range(0, FollowerHolder.transform.childCount);
            Transform follower = FollowerHolder.transform.GetChild(randomF);
            follower.GetComponent<FollowerController>().enabled = false;
            follower.GetComponent<EnemyController>().enabled = true;
            BritainVsIndia.value = 0.5f;

        }
        
        if (FoodVsEqu.value == FoodVsEqu.maxValue || FoodVsEqu.value == FoodVsEqu.minValue)
        {
            int randomF = Random.Range(0, FollowerHolder.transform.childCount);
            Transform follower = FollowerHolder.transform.GetChild(randomF);
            follower.GetComponent<FollowerController>().enabled = false;
            follower.GetComponent<EnemyController>().enabled = true;
            FoodVsEqu.value = 0.5f;

        }
        
        if (HinduVsReli.value == HinduVsReli.maxValue || HinduVsReli.value == HinduVsReli.minValue)
        {
            int randomF = Random.Range(0, FollowerHolder.transform.childCount);
            Transform follower = FollowerHolder.transform.GetChild(randomF);
            follower.GetComponent<FollowerController>().enabled = false;
            follower.GetComponent<EnemyController>().enabled = true;
            HinduVsReli.value = 0.5f;

        }



    }
    
    IEnumerator SpawnButton()
    {
        time = 0;
        randm = Random.Range(2, 8);
        transform.GetChild(randm).gameObject.SetActive(true);
        t_image.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        transform.GetChild(randm).gameObject.SetActive(false);
        t_image.gameObject.SetActive(false);

    }
    
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    public void ButtonClicked()
    {
        SetNeeds(0.1f);
        transform.GetChild(randm).gameObject.SetActive(false);
        t_image.gameObject.SetActive(false);
    }

    
    public void SetNeeds(float need)
    {
        if (randm==2)
        {
            FoodVsEqu.value -= need;
        }
        else if (randm == 3)
        {
            FoodVsEqu.value += need;
        }
        else if (randm == 4)
        {
            BritainVsIndia.value -= need;
        }
        else if(randm == 5)
        {
            BritainVsIndia.value += need;
        }
        else if (randm == 6)
        {
            HinduVsReli.value -= need;
        }
        else if (randm == 7)
        {
            HinduVsReli.value += need;
        }
        
       
    }

}
