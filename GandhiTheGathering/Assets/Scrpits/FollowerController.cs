﻿using System.Collections;
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
     
        gameObject.tag = "Player";
        gameObject.layer = 9;
        gameObject.GetComponent<MeshRenderer>().material = follower;
        if (!inSight)
        {
            Follow();
        }
        else if (inSight)
        {
            
        }
        if (CurrentFaith<=0)
        {
            Destroy(gameObject);
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            MinusFaith(1);
        }
    }
}
