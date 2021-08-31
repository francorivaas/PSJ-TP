using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if (canShoot)
        {
            currentAmmo--;
            BulletController b = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            b.SetAnOwner(this);
        }
    }

    //public Pistol Clone()
    //{
    //    Pistol pistol = new Pistol();
    //    return pistol;
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        Clone();
    //    }
    //}
}
