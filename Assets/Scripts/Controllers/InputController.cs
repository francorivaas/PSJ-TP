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
        if (Input.GetKey(KeyCode.W)) playerMovement.Move(transform.forward, "IsRunning", true);
        if (Input.GetKey(KeyCode.A)) playerMovement.Move(-transform.right, "IsRunning", true);
        if (Input.GetKey(KeyCode.S)) playerMovement.Move(-transform.forward, "IsRunning", true);
        if (Input.GetKey(KeyCode.D)) playerMovement.Move(transform.right, "IsRunning", true);

        if (Input.GetKeyUp(KeyCode.W)) playerMovement.Move(Vector3.zero, "IsRunning", false);
        if (Input.GetKeyUp(KeyCode.A)) playerMovement.Move(Vector3.zero, "IsRunning", false);
        if (Input.GetKeyUp(KeyCode.S)) playerMovement.Move(Vector3.zero, "IsRunning", false);
        if (Input.GetKeyUp(KeyCode.D)) playerMovement.Move(Vector3.zero, "IsRunning", false);
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
