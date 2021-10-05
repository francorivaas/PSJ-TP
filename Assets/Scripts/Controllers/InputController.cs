using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    private MovementController playerMovement;
    private ShootingController playerWeapon;

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";

    public Action<float, float> OnMove;
    public event Action OnMovingAnimation;

    private void Start()
    {
        playerMovement = GetComponent<MovementController>();
        playerWeapon = GetComponent<ShootingController>();
    }

    private void Update()
    {
        CheckMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.JumpCommand.Execute();
        }

        #region PLAYER AIM

        if (Input.GetMouseButtonDown(1)) playerMovement.Aim();
        else if (Input.GetMouseButtonUp(1)) playerMovement.StopAim();

        #endregion PLAYER AIM

        #region PLAYER SHOOT
        if (Input.GetMouseButtonDown(0)) playerWeapon.Shoot();
        if (Input.GetKey(KeyCode.R)) playerWeapon.Weapon.Reload();
        #endregion PLAYER SHOOT
    }

    private void CheckMovement()
    {
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);
        OnMove?.Invoke(horizontal, vertical);
    }
}
