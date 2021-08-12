using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
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
}
