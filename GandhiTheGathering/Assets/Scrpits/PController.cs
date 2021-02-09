using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PController : MonoBehaviour
{
    public Camera camP;
    public NavMeshAgent agentP;
    public LayerMask Ground, IsEnemy;

    public float insp;
    public float col_atm;

    Animator animator;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2, IsEnemy);
        foreach (Collider col in colliders)
        {
            col.gameObject.GetComponent<EnemyController>().TakeDamage(1 / (float)colliders.Length);
            Debug.Log(col.name + " Damaged");
        }
            
               
            
        
        Debug.Log(colliders.Length);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
        }
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            col_atm++;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            col_atm--;
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

        Debug.Log(col_atm);
        
    }
    
    
    
}
