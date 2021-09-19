using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class InputController : MonoBehaviour
{
    private MovementController player;
    private ShootingController weapon;

    private void Start()
    {
        player = GetComponent<MovementController>();
        weapon = GetComponent<ShootingController>();
    }

    private void Update()
    {
        #region PLAYER MOVEMENT

        if (Input.GetKey(KeyCode.W)) player.Move(transform.forward, "IsRunning", true);
        if (Input.GetKey(KeyCode.A)) player.Move(-transform.right, "IsRunning", true);
        if (Input.GetKey(KeyCode.S)) player.Move(-transform.forward, "IsRunning", true);
        if (Input.GetKey(KeyCode.D)) player.Move(transform.right, "IsRunning", true);

        if (Input.GetKeyUp(KeyCode.W)) player.Move(Vector3.zero, "IsRunning", false);
        if (Input.GetKeyUp(KeyCode.A)) player.Move(Vector3.zero, "IsRunning", false);
        if (Input.GetKeyUp(KeyCode.S)) player.Move(Vector3.zero, "IsRunning", false);
        if (Input.GetKeyUp(KeyCode.D)) player.Move(Vector3.zero, "IsRunning", false);

        #endregion PLAYER MOVEMENT

        #region PLAYER AIM

        if (Input.GetMouseButtonDown(1))
        {
            player.Aim();
        }

        else if (Input.GetMouseButtonUp(1))
        {
            player.StopAim();
        }

        #endregion PLAYER AIM

        #region PLAYER SHOOT

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }

        if (Input.GetKey(KeyCode.R))
        {
            weapon.Weapon.Reload();
        }

        #endregion PLAYER SHOOT

    }
}
