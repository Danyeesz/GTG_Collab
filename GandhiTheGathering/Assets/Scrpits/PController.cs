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

    Animator animator;
    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.parent.name == "CrowdOfThree")
        {
            InspirationManager.CrowdSize = 3;
            if (other.transform.parent.childCount == 1)
            {
                insp += 0.3f;
                InspirationManager.InspBar.SetInsp(insp);
            }
            
        }
        Debug.Log(insp);
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
