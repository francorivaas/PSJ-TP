using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class InputController : MonoBehaviour
{
    private MovementController player;

    private void Start()
    {
        player = GetComponent<MovementController>();    
    }

    void Update()
    {
        #region PLAYER MOVEMENT

        if (Input.GetKey(KeyCode.W)) player.Move(transform.forward, "IsRunning", true);
        if (Input.GetKey(KeyCode.A)) player.Move(-transform.right, "IsRunning", true);
        if (Input.GetKey(KeyCode.S)) player.Move(-transform.forward, "IsRunning", true);
        if (Input.GetKey(KeyCode.D)) player.Move(transform.right, "IsRunning", true);

        #endregion PLAYER MOVEMENT
    }
}
