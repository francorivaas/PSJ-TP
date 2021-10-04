using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    [SerializeField] private Vector3 rotationSensibility;

    private Rigidbody body;
    private Animator animator;

    private float rotX;
    private float rotY;
    private float maxSpeed;

    private bool canMove;
    private bool isAiming;

    private MoveCommand moveForward;
    private MoveCommand moveBackwards;
    private MoveCommand moveLeft;
    private MoveCommand moveRight;
    private MoveCommand stop;

    public MoveCommand MoveForward => moveForward;
    public MoveCommand MoveBackwards => moveBackwards;
    public MoveCommand MoveLeft => moveLeft;
    public MoveCommand MoveRight => moveRight;
    public MoveCommand Stop => stop;

    private void Start()
    {
        #region Get Components

        body = GetComponentInParent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        #endregion Get Components

        maxSpeed = actorStats.Speed;

        canMove = true;

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        moveForward = new MoveCommand(transform, Vector3.forward, actorStats);
        moveBackwards = new MoveCommand(transform, Vector3.back, actorStats);
        moveLeft = new MoveCommand(transform, Vector3.left, actorStats);
        moveRight = new MoveCommand(transform, Vector3.right, actorStats);
        stop = new MoveCommand(transform, Vector3.zero, actorStats);
    }

    private void Update()
    {
        CheckRotation();
    }

    public void Aim()
    {
        canMove = false;
        animator.SetBool("IsAiming", true);
    }
    
    public void StopAim()
    {
        isAiming = false;
        animator.SetBool("IsAiming", false);
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

    #region COLLISION CHECK WITH GROUND

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && !isAiming)
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
