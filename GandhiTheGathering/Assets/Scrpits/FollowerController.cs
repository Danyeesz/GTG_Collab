using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
  

    public NavMeshAgent agentF;
    public Transform player;
    public Transform enemy;
    public FaithBar faithBar;
    public Slider InspBar;
    public Animator animator;
    public Material [] followermats;

    public LayerMask isEnemy, isFollower;
    Vector3 ins_pos;

    public float sightRange;
    public bool inSight;
    public float MaxFaith;
    public float CurrentFaith;
    public int col_atm;

 
 
    private void OnEnable()
    {

        transform.GetChild(0).gameObject.SetActive(true);

        gameObject.tag = "Follower";
        gameObject.layer = isFollower;

        agentF = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Gandhi").transform;
        CurrentFaith = MaxFaith;
        faithBar.SetMaxFaith(MaxFaith);

        InspBar = GameObject.FindGameObjectWithTag("Insp_Slider").GetComponent<Slider>();
        
        transform.GetChild(1).Find("Box003").GetComponent<SkinnedMeshRenderer>().material = followermats[Random.Range(0, 3)];


        animator = GetComponentInChildren<Animator>();

    }

    private void OnDisable()
    {
        gameObject.GetComponent<EnemyController>().enabled = true;
    }

    private void FixedUpdate()
    {

        Collider[] colliders = new Collider[300];
        colliders = Physics.OverlapSphere(transform.position, sightRange, isEnemy);
        for (int i = 0; i < colliders.Length; i++)
        {

            if (colliders[i].tag == "Enemy")
            {
                Vector3 dir = (colliders[i].transform.position - transform.position).normalized;
                dir.y *= 0;

                Ray ray = new Ray(transform.position, colliders[i].transform.position - transform.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, sightRange, isEnemy))
                {

                    if (hit.transform.tag == "Enemy")
                    {
                        inSight = true;
                        ins_pos = hit.transform.position;
                    }

                }
                Debug.DrawRay(transform.position, colliders[i].transform.position - transform.position);
            }
            else
            {
                inSight = false;
            }
        }
      

    }
    // Update is called once per frame
    void Update()
    {
        
        if (!inSight)
        {
            Follow();
        }
        else if (inSight)
        {
            Chase();
            Vector3 Pdistance = player.position - transform.position;
            if (Pdistance.magnitude >=40)
            {
                Follow();
            }
        }
        if (CurrentFaith<=0)
        {

            gameObject.GetComponent<FollowerController>().enabled = false;
         



        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restore(1f);
        }
    }

    private void Follow() {

        agentF.stoppingDistance = 1.5f;
        agentF.SetDestination(player.position);

    }

    private void Chase()
    {

        agentF.SetDestination(ins_pos);
       
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
        InspBar.value = 0f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            col_atm++;
            animator.SetInteger("ArgueNum", UnityEngine.Random.Range(1, 2));
            animator.SetBool("IsArguing", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            col_atm--;
            animator.SetBool("IsArguing", false);
        }

    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().health -= 1 / col_atm;
            Debug.Log(transform.name +" is Damaging" + collision.transform.name);
            inSight = true;
        }
        else
        {
            inSight = false;
        }
    }
}
