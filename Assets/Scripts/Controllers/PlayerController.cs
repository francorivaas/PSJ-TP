using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon { get => weapon; set => weapon = value; }
    private LifeController life;

    private void Start()
    {
        life = GetComponent<LifeController>();

        life.Death += Life_Death;    
    }

    private void Life_Death()
    {
        Debug.Log("lol");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }

        if (Input.GetKey(KeyCode.R))
        {
            weapon.Reload();
        }
    }
}
