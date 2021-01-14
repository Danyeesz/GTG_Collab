using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
    public float MaxFaith = 5;
    public float CurrentFaith;

    public NavMeshAgent agentF;
    public Transform player;

    public Material follower;
    public float sightRange;
    public LayerMask isEnemy;
    public bool inSight;

    public FaithBar FaithBar;

    private void Start()
    {
        agentF = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        CurrentFaith = MaxFaith;
        FaithBar.SetMaxFaith(MaxFaith);
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, sightRange, isEnemy);
        gameObject.tag = "Player";
        gameObject.GetComponent<MeshRenderer>().material = follower;
        if (!inSight)
        {
            Follow();
        }
        else if (inSight)
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MinusFaith(1);
        }

    }

    private void Follow() {

        agentF.stoppingDistance = 1.5f;
        agentF.SetDestination(player.position);

    }

    private void MinusFaith(float mfaith) 
    {

        CurrentFaith -= mfaith;
        FaithBar.SetFaith(CurrentFaith);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            FaithBar.SetFaith(CurrentFaith - 1);
        }
    }
}
