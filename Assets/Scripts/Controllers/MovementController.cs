using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    //private float moveForward;
    //private float moveSide;
    private float rotX;
    private float rotY;
    [SerializeField] private Vector3 rotationSensibility;

    private Rigidbody body;
    private Animator animator;

    private bool isMoving;
    private bool canMove;

    private float maxSpeed;
    //private float speedMultiplier = 2.0f;

    private void Start()
    {
        #region Get Components
        body = GetComponentInParent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        #endregion Get Components

        canMove = true;
        maxSpeed = actorStats.Speed;
    }

    private void Update()
    {
        Debug.Log(canMove);

        CheckRotation();
        CheckMovement();
        CheckAiming();
        CheckSprint();

        #region MOVING WITH RB
        //if (isMoving)
        //{
        //    moveForward = Input.GetAxisRaw("Vertical") * actorStats.Speed;    
        //    moveSide = Input.GetAxisRaw("Horizontal") * actorStats.Speed;
        //}
        //body.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * body.velocity.y);
        #endregion MOVING WITH RB

    }

    public void Move(Vector3 direction, string animation, bool value)
    {
        if (canMove)
        {
            body.velocity = direction * maxSpeed;
            animator.SetBool(animation, value);
        }

        //transform.position += direction * actorStats.Speed * Time.deltaTime;
    }

    private void CheckRotation()
    {
        rotX += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSensibility.x;
        rotY += Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSensibility.y;

        if (rotX >= 360)
        {
            rotX = 0.0f;
        }

        transform.rotation = Quaternion.Euler(new Vector3(-rotY, rotX, 0.0f));
    }

    private void CheckMovement()
    {
        //if (canMove)
        //{
            #region OBSOLETE CODE
            //if (Input.GetKey(KeyCode.W))
            //{
            //    isMoving = true;
            //    body.velocity = transform.forward * maxSpeed;
            //}

            //else if (Input.GetKey(KeyCode.S))
            //{
            //    isMoving = true;
            //    body.velocity = -transform.forward * maxSpeed;
            //}

            //else if (Input.GetKey(KeyCode.D))
            //{
            //    isMoving = true;
            //    body.velocity = transform.right * maxSpeed;
            //}

            //else if (Input.GetKey(KeyCode.A))
            //{
            //    isMoving = true;
            //    body.velocity = -transform.right * maxSpeed;
            //}
            /*else */
            #endregion OBSOLETE CODE

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
            {
                isMoving = false;
                body.velocity = Vector3.zero;
                animator.SetBool("IsRunning", false);
            }

            if (isMoving) animator.SetBool("IsRunning", true);
        //}
    }

    private void CheckSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isMoving)
        {
            maxSpeed = maxSpeed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isMoving)
        {
            maxSpeed = actorStats.Speed;
        }
    }

    private void CheckAiming()
    {
        if (Input.GetMouseButtonDown(1))
        {
            canMove = false;
            animator.SetBool("IsAiming", true);
        }

        else if (Input.GetMouseButtonUp(1))
        {
            canMove = true;
            animator.SetBool("IsAiming", false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canMove = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canMove = false;
        }
    }
}
