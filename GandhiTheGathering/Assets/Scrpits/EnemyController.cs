﻿using System.Collections;
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
    float health;
    public Material Enemy;
    public Vector3 destDist;







    private void Start()
    {
        
        gameObject.GetComponent<MeshRenderer>().material = Enemy;
        agentE = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        transform.GetChild(0).gameObject.SetActive(false);
        health = P_health;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, sightRange, isPlayer)|| 
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, sightRange, isPlayer)|| 
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, sightRange, isPlayer)||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, sightRange, isPlayer))
        {
            inSight = true;
           
        }
     
       
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*sightRange,Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * sightRange, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * sightRange, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * sightRange, Color.yellow);


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
            gameObject.GetComponent<FollowerController>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            this.transform.parent = GameObject.Find("Followers").transform;
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

    }

    private void SetDest() {

        float randomZ = Random.Range(-destRange, destRange);
        float randomX = Random.Range(-destRange, destRange);
        destV = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(destV, -transform.up,2f,isGround))
        {
            dest.position = destV;
            destSet = true;

        }

    }

   
  

}
