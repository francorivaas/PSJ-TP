using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int bulletSpread = 5;

    public override void Shoot()
    {
        if (canShoot)
        {
            currentAmmo--;

            for (int i = 0; i < bulletSpread; i++)
            {
                BulletController b = Instantiate(bullet, transform.position + Random.insideUnitSphere * 1, Quaternion.identity);
                b.SetAnOwner(this);
            }
        }
    }
}
