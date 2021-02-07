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

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnDisable()
    {
        gameObject.GetComponent<EnemyController>().enabled = true;
    }

   
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, sightRange, isEnemy) ||
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, sightRange, isEnemy) ||
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, sightRange, isEnemy) ||
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, sightRange, isEnemy))
        {
            //inSight = true;
           
        }



        else
        {
            inSight = false;
        }
       
        if (!inSight)
        {
            Follow();
        }
       /* else if (inSight)
        {
            Chase();
            Vector3 Pdistance = player.position - transform.position;
            if (Pdistance.magnitude >=400)
            {
                Follow();
            }
        }*/
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
            animator.SetBool("IsArguing", true);
            animator.SetInteger("ArgueNum", UnityEngine.Random.Range(1, 2));
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Hello");
            animator.SetBool("IsArguing", false);
        }
    }
}
