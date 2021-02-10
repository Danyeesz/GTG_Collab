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
        
        while (GameTime<100)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {

                    Instantiate(CrowdOfThree, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(50);
        }

        while (GameTime >= 100f && GameTime <= 200f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {

                    Instantiate(CrowdOfFive, Spawns[i].position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(50);
        }

        while (GameTime >= 200f && GameTime <= 300f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {
                    Instantiate(CrowdOfTen, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(100);
        }
        while (GameTime >= 300f && GameTime <= 400f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {
                    Instantiate(CrowdOfTen, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(50);
        }
        while (GameTime >= 400f && GameTime <= 500f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {
                    Instantiate(CrowdOfTen, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(50);
        }
        while (GameTime >= 500f)
        {
            for (int i = 0; i < Spawns.Length; i++)
            {
                if ((Player.position - Spawns[i].position).magnitude >= 20)
                {
                    Instantiate(CrowdOfTen, Spawns[i].position, Quaternion.identity);
                }

            }
            yield return new WaitForSeconds(30);
        }
    }
}
