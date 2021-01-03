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

    public Vector3 dest;
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

    private void Patrol()
    {
        if (!destSet)
        {
            SetDest();
        }
        else
        {
            agentE.SetDestination(dest);
        }

        if (gameObject.transform.position == dest)
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
        dest = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(dest, -transform.up,2f,isGround))
        {
            destSet = true;
        }

    }
   
}
