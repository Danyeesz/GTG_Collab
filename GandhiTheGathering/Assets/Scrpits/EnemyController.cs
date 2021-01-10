using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    
    public NavMeshAgent agentE;
    public Transform player;
    public LayerMask isGround, isPlayer;
    public bool inSight;

    public Material follower;
    


    public Transform dest;
    public Vector3 destV;
    public float destRange, sightRange;
    bool destSet;



    private void Start()
    {
        agentE = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
    }

    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, sightRange, isPlayer);

        if (!inSight)
        {
            Patrol();
        }
        else if (inSight)
        {
            Chase();
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            agentE.stoppingDistance = 1.5f;
            agentE.SetDestination(player.position);
            gameObject.GetComponent<MeshRenderer>().material = follower;
            gameObject.tag = "Player";

            

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

        Vector3 destDist = transform.position - destV;

        if (destDist.magnitude <1f)
        {
            destSet = false;
        }

        
    }

    private void Chase() {
       
            agentE.SetDestination(player.position);
        
        

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
