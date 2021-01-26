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


    void Start()
    {
        Instantiate(CrowdOfThree, Spawn1.transform.position, Quaternion.identity);
        Instantiate(CrowdOfFive, Spawn2.transform.position, Quaternion.identity);
        Instantiate(CrowdOfThree, Spawn3.transform.position, Quaternion.identity);
        Instantiate(CrowdOfThree, Spawn1.transform.position, Quaternion.identity);
        Instantiate(CrowdOfFive, Spawn2.transform.position, Quaternion.identity);
        Instantiate(CrowdOfThree, Spawn3.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
