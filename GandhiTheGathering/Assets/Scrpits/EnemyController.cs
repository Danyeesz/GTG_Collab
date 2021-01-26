﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    
    public NavMeshAgent agentE;
    public Transform player;
    public LayerMask isGround, isPlayer, isFollower;
    public bool inSight;

    public Transform dest;
    public Vector3 destV;
    public float destRange, sightRange;
    bool destSet;
    public float P_health;
    public float health;
    public Material Enemy;
    public Vector3 destDist;

    



    private void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material = Enemy;
        health = P_health;
        transform.GetChild(0).gameObject.SetActive(false);
        agentE = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        
    }

    private void OnDisable()
    {
        gameObject.GetComponent<FollowerController>().enabled = true;
    }


    private void Start()
    {
        
        
        
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void FixedUpdate()
    {

        Collider[] colliders = new Collider[5000];
        colliders = Physics.OverlapSphere(transform.position, sightRange, isPlayer);
        for (int i = 0; i < colliders.Length; i++)
        {

            if (colliders[i].tag == "Player")
            {
                Vector3 dir = (colliders[i].transform.position - transform.position).normalized;
                dir.y *= 0;

                Ray ray = new Ray(transform.position, colliders[i].transform.position - transform.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, sightRange))
                {
                    if (hit.transform.tag == "Player")
                    {
                        inSight = true;

                    }

                }
                Debug.DrawRay(transform.position, colliders[i].transform.position - transform.position);
            }
        }


    }

    private void Update()
    {


     


        if (!inSight)
        {
            Patrol();
        }
        else if (inSight)
        {
            Chase();
        
        }

        if (health<=0)
        {
            
           
            gameObject.GetComponent<EnemyController>().enabled = false;
            
        }

        
    }

   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            health = health - 1;
        }
    }

    private void Patrol()
    {
        if (!destSet)
        {
            SetDest();
        }
        else
        {
            agentE.SetDestination(dest.position);
        }

        destDist = transform.position - destV;

        if (destDist.magnitude <= 2f)
        {
            destSet = false;
        }

        
    }

    private void Chase() {

        agentE.SetDestination(player.position) ;
        destSet = true;

    }

    private void SetDest() {

        float randomZ = UnityEngine.Random.Range(-destRange, destRange);
        float randomX = UnityEngine.Random.Range(-destRange, destRange);
        destV = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(destV, -transform.up,2f,isGround))
        {
            dest.position = destV;
            destSet = true;

        }

    }

   
  

}
