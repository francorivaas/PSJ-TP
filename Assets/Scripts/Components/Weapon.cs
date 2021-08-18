using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IGun
{
    //me va a cambiar la currentAmmo de todas las guns ?-------------------//
    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }
    protected int currentAmmo;
    //--------------------------------------------------------------------//

    public int Damage => damage;
    [SerializeField] protected int damage;

    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] protected BulletController bullet;
    [SerializeField] protected Text ammoText;

    protected bool canShoot;

    private void Start()
    {
        canShoot = true;
        currentAmmo = weaponStats.MaxAmmo;
    }

    private void Update()
    {
        ammoText.text = currentAmmo + "/" + weaponStats.MaxAmmo;
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        canShoot = currentAmmo <= 0 ? false : true;
    }

    public void Reload()
    {
        currentAmmo = weaponStats.MaxAmmo;
    }

    public virtual void Shoot()
    {
        if (canShoot)
        {
            currentAmmo--;
            BulletController b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.SetAnOwner(this);
        }
    }
}
