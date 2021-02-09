using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PController : MonoBehaviour
{
    public Camera camP;
    public NavMeshAgent agentP;
    public LayerMask Ground, IsEnemy;
    public float damageG;

    public AudioSource audio;
    public AudioClip argue;

    Animator animator;
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2, IsEnemy);
        foreach (Collider col in colliders)
        {
            col.gameObject.GetComponent<EnemyController>().TakeDamage(damageG /(float)colliders.Length);
           
        }
       
      
    }

  


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camP.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Ground))
            {
               
                agentP.SetDestination(hit.point);
               
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
