using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{

    public Animator animator;
    public Rigidbody Rigidbody;
    Vector3 previousFramePosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Rigidbody = gameObject.GetComponentInParent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = (gameObject.transform.position - previousFramePosition) / Time.deltaTime;
        Vector2 velocity2D = new Vector2(velocity.x, velocity.z);
        animator.SetFloat("Speed", velocity2D.magnitude);
        previousFramePosition = gameObject.transform.position;  
       
    }
}
