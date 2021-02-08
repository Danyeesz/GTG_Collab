using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PController : MonoBehaviour
{
    public Camera camP;
    public NavMeshAgent agentP;
    public LayerMask Ground;

    public float insp;
    public float col_atm;

    Animator animator;
    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.GetComponent<EnemyController>().Currenthealth -= (1/col_atm);
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

      
        
    }
    
    
    
}
