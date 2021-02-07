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
    int col_atm;

    Animator animator;
    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

       
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
