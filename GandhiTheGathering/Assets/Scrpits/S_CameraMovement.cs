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
            Transform hitobj = hit.transform;
            Debug.Log(hit.transform.name);
            Renderer obj = hit.transform.GetComponent<Renderer>();
            Material mats = obj.material;
            Debug.Log(obj.material.name);
            obj.material = transp;
            if (hitobj.name != hit.transform.name)
            {
                hitobj.GetComponent<Renderer>().material = mats;
            }
        }

    }
}
