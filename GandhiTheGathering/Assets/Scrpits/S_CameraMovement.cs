using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothspeed = 0.125f;
    public Vector3 offset;

    public Camera cam;
    public LayerMask Objects;

    public Material transp;
    Transform hitObj;
    Material[] oldMats;
    Renderer rend;
   




    private void Start()
    {
        transform.position = target.transform.position + offset;
        
    }

    private void FixedUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        transform.position = smoothedPosition;
        Transparent();
    }

    private void Transparent() 
    {
        Debug.DrawRay(transform.position, target.transform.position - transform.position);

        Ray ray = new Ray(transform.position, target.transform.position - transform.position);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Objects);
        if (hit.transform.name != "Gandhi")
        {
            hitObj = hit.transform;

            
            rend = hit.transform.GetComponent<Renderer>();
            oldMats = rend.materials;
            Material[] newMats = new Material[oldMats.Length];
            for (int i = 0; i < newMats.Length; i++)
            {
                newMats[i] = transp;
            }
            rend.materials = newMats;

        }


        if (hitObj != null)
        {
            if (Vector3.Distance(hitObj.position, target.position) >= 1.5f)
            {
                rend.materials = hitObj.GetComponent<OriginalMat>().omats;
            }
        }
       
        
        

    }
}
