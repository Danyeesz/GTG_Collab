using System.Collections;
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
    public Animator animator;

    

    private void OnEnable()
    {
     
        transform.GetChild(1).Find("Box003").GetComponent<SkinnedMeshRenderer>().material = Enemy;
        health = P_health;
        transform.GetChild(0).gameObject.SetActive(false);
        agentE = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        destSet = false;
        

        float randomZ = UnityEngine.Random.Range(-destRange, destRange);
        float randomX = UnityEngine.Random.Range(-destRange, destRange);
        destV = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        dest.position = destV;
        Patrol();
        animator = GetComponentInChildren<Animator>();

    }

    private void OnDisable()
    {
        gameObject.GetComponent<FollowerController>().enabled = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void FixedUpdate()
    {

        Collider[] colliders = new Collider[300];
        colliders = Physics.OverlapSphere(transform.position, sightRange, isPlayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].name);
            if (colliders[i].tag == "Player")
            {
                Vector3 dir = (colliders[i].transform.position - transform.position).normalized;
                dir.y *= 0;

                Ray ray = new Ray(transform.position, colliders[i].transform.position - transform.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, sightRange,isPlayer))
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
            inSight = true;
            animator.SetInteger("ArgueNum", UnityEngine.Random.Range(1, 2));
            animator.SetBool("IsArguing", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            
            animator.SetBool("IsArguing", false);
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

        destV = player.position;
        dest.position = destV;
        agentE.SetDestination(dest.position) ;
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
