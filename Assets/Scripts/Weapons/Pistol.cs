using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon, IGun
{
    public int MaxAmmo { get => maxAmmo; set => maxAmmo = value; }
    public int CurrentAmmo { get; set; }

    private int maxAmmo;
    private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;    
    }

    public override void Attack()
    {
        BulletController b = Instantiate(bullet, transform.position, Quaternion.identity);
        b.SetAnOwner(this);
    }

    public void Reload()
    {
        if (currentAmmo <= 0)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
        }
    }
}
