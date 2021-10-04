using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    private MovementController playerMovement;
    private ShootingController playerWeapon;

    //private string horizontalAxis = "Horizontal";
    //private string verticalAxis = "Vertical";
    //public Action<float, float> OnMove;

    private void Start()
    {
        playerMovement = GetComponent<MovementController>();
        playerWeapon = GetComponent<ShootingController>();
    }

    private void Update()
    {
        #region PLAYER MOVEMENT
        if (Input.GetKey(KeyCode.W)) playerMovement.MoveForward.Execute();
        if (Input.GetKey(KeyCode.A)) playerMovement.MoveLeft.Execute();
        if (Input.GetKey(KeyCode.S)) playerMovement.MoveBackwards.Execute();
        if (Input.GetKey(KeyCode.D)) playerMovement.MoveRight.Execute();

        if (Input.GetKeyUp(KeyCode.W)) playerMovement.Stop.Execute();
        if (Input.GetKeyUp(KeyCode.A)) playerMovement.Stop.Execute();
        if (Input.GetKeyUp(KeyCode.S)) playerMovement.Stop.Execute();
        if (Input.GetKeyUp(KeyCode.D)) playerMovement.Stop.Execute();
        #endregion PLAYER MOVEMENT

        #region PLAYER AIM

        if (Input.GetMouseButtonDown(1)) playerMovement.Aim();
        else if (Input.GetMouseButtonUp(1)) playerMovement.StopAim();

        #endregion PLAYER AIM

        #region PLAYER SHOOT
        if (Input.GetMouseButtonDown(0)) playerWeapon.Shoot();
        if (Input.GetKey(KeyCode.R)) playerWeapon.Weapon.Reload();
        #endregion PLAYER SHOOT
    }
}
