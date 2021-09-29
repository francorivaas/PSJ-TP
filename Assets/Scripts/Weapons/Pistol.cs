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
        base.Shoot();
        if (HasAmmo)
        {
            AudioManager.instance.PlaySound(SoundClips.Shoot);

            currentAmmo--;
            //BulletController b = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            //b.SetAnOwner(this);

            muzzleFlash.Play();

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                var go = hit.transform.gameObject;
                if (go.layer == LayerMask.NameToLayer("Enemy"))
                {
                    LifeController lc = go.GetComponent<LifeController>();
                    lc.TakeDamage(damage);
                }
            }
        }
    }
}
