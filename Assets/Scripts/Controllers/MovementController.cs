using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    [SerializeField] private Vector3 rotationSensibility;

    private InputController input;
    private Animator animator;
    
    public event Action Moving;
    
    private float rotX;
    private float rotY;
    private float maxSpeed;

    private bool canMove;
    private bool isAiming;

    //private MoveCommand moveForward;
    //private MoveCommand moveBackwards;
    //private MoveCommand moveLeft;
    //private MoveCommand moveRight;
    //private MoveCommand stop;

    //public MoveCommand MoveForward => moveForward;
    //public MoveCommand MoveBackwards => moveBackwards;
    //public MoveCommand MoveLeft => moveLeft;
    //public MoveCommand MoveRight => moveRight;
    //public MoveCommand Stop => stop;

    private void Start()
    {
        #region Get Components
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<InputController>();
        #endregion Get Components

        maxSpeed = actorStats.Speed;

        canMove = true;

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        input.OnMove += Move;
        //moveForward = new MoveCommand(transform, transform.forward, actorStats);
        //moveBackwards = new MoveCommand(transform, -transform.forward, actorStats);
        //moveLeft = new MoveCommand(transform, -transform.right, actorStats);
        //moveRight = new MoveCommand(transform, transform.right, actorStats);
        //stop = new MoveCommand(transform, Vector3.zero, actorStats);
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        transform.position += movement * actorStats.Speed * Time.deltaTime;

        animator.SetBool("IsRunning", true);
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
