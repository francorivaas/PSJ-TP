using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Attack();
        }
    }
}
