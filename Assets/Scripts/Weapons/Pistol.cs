using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon, IGun
{
    public int MaxAmmo { get => maxAmmo; set => maxAmmo = value; }
    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }

    private int maxAmmo = 10;
    [SerializeField] private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;    
    }

    public override void Attack()
    {
        BulletController b = Instantiate(bullet, firePoint.position, Quaternion.identity);
        currentAmmo--;
        b.SetAnOwner(this);
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
    }
}
