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

    public Transform dest;
    public Vector3 destV;
    public float destRange, sightRange;
    bool destSet;
    public float health;
    



    private void Start()
    {
        agentE = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit,sightRange,isPlayer))
        {
            inSight = true;
        }
       
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*sightRange,Color.yellow);


        if (!inSight)
        {
            Patrol();
        }
        else if (inSight)
        {
            Chase();
        }

        if (health==0)
        {
            gameObject.GetComponent<FollowerController>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
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
