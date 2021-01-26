using System.Collections;
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

    private Collider[] overlaps;






    private void Start()
    {
        
        gameObject.GetComponent<MeshRenderer>().material = Enemy;
        agentE = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        transform.GetChild(0).gameObject.SetActive(false);
        health = P_health;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    void Update()
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
        destSet = true;

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
