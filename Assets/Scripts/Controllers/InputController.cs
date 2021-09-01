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
        if (Input.GetKey(KeyCode.W)) player.Move(transform.forward);
        if (Input.GetKey(KeyCode.A)) player.Move(-transform.right);
        if (Input.GetKey(KeyCode.S)) player.Move(-transform.forward);
        if (Input.GetKey(KeyCode.D)) player.Move(transform.right);
        #endregion PLAYER MOVEMENT
    }
}
