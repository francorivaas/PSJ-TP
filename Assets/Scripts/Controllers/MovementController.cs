using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    private float rotX;
    private float rotY;
    [SerializeField] private Vector3 rotationSensibility;

    private Rigidbody body;
    private Animator animator;

    private bool isMoving;
    private bool canMove;

    private float maxSpeed;

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
        CheckRotation();
        CheckSprint();
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
    public void Aim(bool value, string animation, bool animationValue)
    {
        canMove = value;
        animator.SetBool(animation, animationValue);
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

    #region COLLISION CHECK WITH GROUND

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

    #endregion COLLISION CHECK WITH GROUND
}
