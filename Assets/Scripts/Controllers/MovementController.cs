using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    [SerializeField] private Vector3 rotationSensibility;

    private InputController input;
    private Animator animator;
    private Rigidbody body;

    public event Action Moving;
    
    private float rotX;
    private float rotY;
    private float maxSpeed;

    private bool canMove;
    private bool isAiming;

    private JumpCommand jumpCommand;
    public JumpCommand JumpCommand => jumpCommand;

    private void Start()
    {
        #region Get Components
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<InputController>();
        body = GetComponent<Rigidbody>();
        #endregion Get Components

        maxSpeed = actorStats.Speed;

        canMove = true;

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        if (canMove)
        {
            input.OnMove += Move;
            jumpCommand = new JumpCommand(body, transform.up, 100f, ForceMode.Acceleration);
            Moving?.Invoke();
        }
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        transform.position += movement * actorStats.Speed * Time.deltaTime;
    }

    private void Update()
    {
        CheckRotation();
        body.AddForce(Vector3.up * 2f);
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

    private void OnCollisionEnter(Collision collision)
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
