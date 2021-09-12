using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Camera cam;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private Light pointLight;

    private float range = 100f;

    public override void Shoot()
    {
        if (canShoot)
        {
            currentAmmo--;
            //BulletController b = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            //b.SetAnOwner(this);

            muzzleFlash.Play();

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);


                var go = hit.transform.gameObject;
                if (go.layer == LayerMask.NameToLayer("Enemy"))
                {
                    LifeController lc = go.GetComponent<LifeController>();
                    lc.TakeDamage(damage);
                }
            }
        }
        else if (!canShoot)
        {
            muzzleFlash.Stop();
        }
    }
}
