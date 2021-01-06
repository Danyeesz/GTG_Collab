using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothspeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        transform.position = target.transform.position + offset;
    }

    private void FixedUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
