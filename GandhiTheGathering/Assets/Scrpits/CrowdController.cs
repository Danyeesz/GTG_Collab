using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public GameObject CrowdOfFive;
    public GameObject CrowdOfThree;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public int MaxCrowd;
    public float WaitSecs;
    public float GameTime;


    void Start()
    {

        StartCoroutine(CrowdSpawn());

    }

    private void FixedUpdate()
    {
        GameTime += Time.deltaTime;
      
    }




    IEnumerator CrowdSpawn() {

        while (GameTime<60)
        {
            Instantiate(CrowdOfThree, Spawn1.transform.position, Quaternion.identity);
            Instantiate(CrowdOfThree, Spawn2.transform.position, Quaternion.identity);
            Instantiate(CrowdOfThree, Spawn3.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(60);
        }

        while (GameTime >= 60f && GameTime <= 120f)
        {
            Instantiate(CrowdOfThree, Spawn1.transform.position, Quaternion.identity);
            Instantiate(CrowdOfThree, Spawn2.transform.position, Quaternion.identity);
            Instantiate(CrowdOfFive, Spawn3.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(60);
        }

        while (GameTime >= 60f && GameTime <= 120f)
        {
            Instantiate(CrowdOfThree, Spawn1.transform.position, Quaternion.identity);
            Instantiate(CrowdOfThree, Spawn2.transform.position, Quaternion.identity);
            Instantiate(CrowdOfFive, Spawn3.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(60);
        }

       
        
    }
}
