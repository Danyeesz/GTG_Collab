using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PController : MonoBehaviour
{
    public Camera camP;
    public NavMeshAgent agentP;
    public Animator animator;
    public LayerMask Ground;

    public float insp;
    public int col_atm;

    
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {
            col_atm++;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Enemy")
        {
            col_atm--;
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.transform.parent.name == "CrowdOfThree")
            {

                InspirationManager.CrowdSize = 3;
                if (other.transform.parent.childCount <= 2)
                {
                    insp += 0.3f;
                    InspirationManager.InspBar.SetInsp(insp);
                }

            }
            other.GetComponent<EnemyController>().health -= 1/col_atm;
        }
        

        Debug.Log(insp);
    }

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
