using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon { get => weapon; set => weapon = value; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }
    }
}
