using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
    public float MaxFaith;
    public float CurrentFaith;
    public static int f_number;

    public NavMeshAgent agentF;
    public Transform player;
    public Transform enemy;

    public Material follower;
    public float sightRange;
    public LayerMask isEnemy;
    public bool inSight;
    

    public FaithBar faithBar;
    public Slider InspBar;

    private void Start()
    {
        agentF = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        CurrentFaith = MaxFaith;
        faithBar.SetMaxFaith(MaxFaith);
        f_number++;
        InspBar = GameObject.FindGameObjectWithTag("Insp_Slider").GetComponent<Slider>();
        
        gameObject.layer = 9;
        gameObject.GetComponent<MeshRenderer>().material = follower;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, sightRange, isEnemy) ||
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, sightRange, isEnemy) ||
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, sightRange, isEnemy) ||
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, sightRange, isEnemy))
        {
            inSight = true;
            enemy.position = hit.transform.position;
        }

       

        else
        {
            inSight = false;
        }
       
        if (!inSight)
        {
            Follow();
        }
        else if (inSight)
        {
            Chase();
            Vector3 Pdistance = player.position - transform.position;
            if (Pdistance.magnitude >=400)
            {
                Follow();
            }
        }
        if (CurrentFaith<=0)
        {
            gameObject.GetComponent<EnemyController>().enabled = true;
            gameObject.GetComponent<FollowerController>().enabled = false;
           
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restore();
        }
    }

    private void Follow() {

        agentF.stoppingDistance = 1.5f;
        agentF.SetDestination(player.position);

    }

    private void Chase()
    {

        agentF.SetDestination(enemy.position);
       
    }

    private void MinusFaith(float mfaith) 
    {

        CurrentFaith -= mfaith;
        faithBar.SetFaith(CurrentFaith);

    }

    public void Restore()
    {

        CurrentFaith = MaxFaith;
        faithBar.SetFaith(CurrentFaith);
        InspBar.value = 0f;

    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            MinusFaith(1);
        }
    }
}
