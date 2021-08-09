using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private float moveForward;
    private float moveSide;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveForward = Input.GetAxisRaw("Vertical") * speed;    
        moveSide = Input.GetAxisRaw("Horizontal") * speed;

        body.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * body.velocity.y);
    }
}
