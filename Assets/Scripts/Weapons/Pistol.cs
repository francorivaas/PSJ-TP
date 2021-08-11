using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon, IGun
{
    int IGun.MaxAmmo { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    int IGun.CurrentAmmo { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Start()
    {
        currentAmmo = maxAmmo;    
    }

    public override void Attack()
    {
        if (canShoot)
        {
            currentAmmo--;
            BulletController b = Instantiate(bullet, firePoint.position, Quaternion.identity);
            b.SetAnOwner(this);
        }
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
    }
}
