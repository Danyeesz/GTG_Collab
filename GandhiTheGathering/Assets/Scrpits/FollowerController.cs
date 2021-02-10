using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
    public float MaxFaith;
    public float CurrentFaith;
    public float col_atm;
    public AudioSource faith0;
    public AudioClip faith0C;

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
    public float speed;
    public float damage;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
       
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.transform.parent = GameObject.Find("Followers").transform;
        gameObject.tag = "Follower";
        gameObject.layer = 11;
        agentF = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        CurrentFaith = MaxFaith;
        faithBar.SetMaxFaith(MaxFaith);

        InspBar = GameObject.FindGameObjectWithTag("Insp_Slider").GetComponent<Slider>();
        
        transform.GetChild(1).Find("Box003").GetComponent<SkinnedMeshRenderer>().material = followermats[Random.Range(0, 3)];

        animator.SetBool("IsArguing", false);


    }

    void FixedUpdate()
    {


        Collider[] colliders = Physics.OverlapSphere(transform.position, 3,LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                colliders[i].transform.GetComponent<EnemyController>().TakeDamage(damage / (float)colliders.Length);
                Debug.Log("Dealing" + (1 / (float)colliders.Length).ToString() + " damage to" + colliders[i].transform.name);
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

            AudioSource.PlayClipAtPoint(faith0C,transform.position);
            Instantiate(smoke_e, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Invoke("DestroyS", 0.5f);
           
            

        }

    }

    public void DestroyS() 
    {

        Destroy(smoke_e);

    }

    private void Follow() {

        agentF.stoppingDistance = 1f;
        agentF.speed = speed;
        agentF.SetDestination(player.position);

    }

    private void Chase()
    {

        agentF.SetDestination(dest);
       
    }

    public void MinusFaith(float mfaith) 
    {

        CurrentFaith -= mfaith;
        faithBar.SetFaith(CurrentFaith);
       
    }

    public void Restore(float faith)
    {
       
        CurrentFaith += faith;
        faithBar.SetFaith(CurrentFaith);
        
      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.GetComponent<FollowerController>().enabled)
        {
            if (other.tag == "Enemy")
            {
                animator.SetBool("IsArguing", true);
                animator.SetInteger("ArgueNum", UnityEngine.Random.Range(1, 2));
            }
            else if (other.tag == "Player")
            {
                animator.SetBool("IsArguing", false);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.GetComponent<FollowerController>().enabled)
        {
            if (other.tag == "Enemy")
            {
                animator.SetBool("IsArguing", false);
            }
            if (other.tag == "Player")
            {
                animator.SetBool("IsArguing", false);
            }
        }
        
    }
}
