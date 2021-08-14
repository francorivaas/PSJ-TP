using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    private float moveForward;
    private float moveSide;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        moveForward = Input.GetAxisRaw("Vertical") * actorStats.Speed;    
        moveSide = Input.GetAxisRaw("Horizontal") * actorStats.Speed;

        body.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * body.velocity.y);
    }
}
