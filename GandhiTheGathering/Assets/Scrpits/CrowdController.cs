using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public GameObject CrowdOfFive;
    public GameObject CrowdOfThree;
    public Transform CrowdOfTen;
    public Transform [] Spawns;
    public int MaxCrowd;
    public float WaitSecs;
    public float GameTime;
    public Transform Player;

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
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {

                    Instantiate(CrowdOfThree, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(10);
        }

        while (GameTime >= 60f && GameTime <= 120f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {

                    Instantiate(CrowdOfFive, Spawns[i].position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(60);
        }

        while (GameTime >= 60f && GameTime <= 120f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {
                    Instantiate(CrowdOfFive, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(60);
        }
    }
}
