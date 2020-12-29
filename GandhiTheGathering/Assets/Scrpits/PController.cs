using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PController : MonoBehaviour
{
    public Camera camP;
    public NavMeshAgent agetP;
    public GameObject followers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camP.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agetP.SetDestination(hit.point);
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            GameObject follow = Instantiate(followers,gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    
}
