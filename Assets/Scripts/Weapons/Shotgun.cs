using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int bulletSpread = 5;
    

    private void Start()
    {
        canShoot = true;
        currentAmmo = maxAmmo;    
    }

    public override void Attack()
    {
        if (canShoot)
        {
            currentAmmo--;

            for (int i = 0; i < bulletSpread; i++)
            {
                BulletController b = Instantiate(bullet, firePoint.position + Random.insideUnitSphere * 1, Quaternion.identity);
                b.SetAnOwner(this);
            }
        }
    }
}
