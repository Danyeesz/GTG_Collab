using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
    public float MaxFaith;
    public float CurrentFaith;

    public NavMeshAgent agentF;
    public Transform player;
    

    public Material [] followermats;
  

    public float sightRange;
    public LayerMask isEnemy;
    public bool inSight;
    

    public FaithBar faithBar;
    public Slider InspBar;

    public ParticleSystem smoke_e;
    public Animator animator;
    public Vector3 dest;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.transform.parent = GameObject.Find("Followers").transform;
        gameObject.tag = "Player";
        gameObject.layer = 9;
        agentF = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        CurrentFaith = MaxFaith;
        faithBar.SetMaxFaith(MaxFaith);

        InspBar = GameObject.FindGameObjectWithTag("Insp_Slider").GetComponent<Slider>();
        
        transform.GetChild(1).Find("Box003").GetComponent<SkinnedMeshRenderer>().material = followermats[Random.Range(0, 3)];


        

    }

    void FixedUpdate()
    {

        Collider[] colliders = new Collider[300];
        colliders = Physics.OverlapSphere(transform.position, sightRange,LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {

            if (colliders[i].tag == "Player")
            {
                Vector3 dir = (colliders[i].transform.position - transform.position).normalized;
                dir.y *= 0;

                Ray ray = new Ray(transform.position, colliders[i].transform.position - transform.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, sightRange, LayerMask.NameToLayer("Enemy")))
                {

                    if (hit.transform.tag == "Enemy")
                    {
                        inSight = true;
                        dest = colliders[1].transform.position;
                    }

                }
                Debug.DrawRay(transform.position, colliders[i].transform.position - transform.position);
            }
        }

        Vector3 Pdistance = player.position - transform.position;
        if (!inSight)
        {
            Follow();
        }
        else if (inSight && Pdistance.magnitude <=50)
        {
            Chase();
        }
        else if (inSight && Pdistance.magnitude > 50)
        {
            Follow();
        }

        if (CurrentFaith<=0)
        {
            
            
            Destroy(gameObject);
            //Instantiate(smoke_e, transform.position, Quaternion.identity);

        }
      
    }

    private void Follow() {

        agentF.stoppingDistance = 1.5f;
        agentF.SetDestination(player.position);

    }

    private void Chase()
    {

        agentF.SetDestination(dest);
       
    }

    private void MinusFaith(float mfaith) 
    {

        CurrentFaith -= mfaith;
        faithBar.SetFaith(CurrentFaith);
       
    }

    public void Restore(float faith)
    {
       
        CurrentFaith += faith;
        faithBar.SetFaith(CurrentFaith);
        
      

    }



    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            MinusFaith(0.1f);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (transform.GetComponent<FollowerController>().enabled)
            {
                animator.SetBool("IsArguing", true);
                animator.SetInteger("ArgueNum", UnityEngine.Random.Range(1, 2));
            }
           
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.GetComponent<FollowerController>().enabled)
        {
            if (other.tag == "Enemy")
            {
                Debug.Log("Hello");
                animator.SetBool("IsArguing", false);
            }
        }
        
    }
}
