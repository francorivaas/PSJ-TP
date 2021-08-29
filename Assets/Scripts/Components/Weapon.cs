using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IGun
{
    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }
    protected int currentAmmo;

    public int Damage => damage;
    [SerializeField] protected int damage;

    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] protected BulletController bullet;
    [SerializeField] protected Text ammoText;
    [SerializeField] protected Transform firePoint;

    protected bool canShoot;

    private void Start()
    {
        canShoot = true;
        currentAmmo = weaponStats.MaxAmmo;
    }

    private void Update()
    {
        ammoText.text = currentAmmo + "/" + weaponStats.MaxAmmo;

        canShoot = currentAmmo <= 0 ? false : true;
    }

    public void Reload()
    {
        currentAmmo = weaponStats.MaxAmmo;
    }

    public virtual void Shoot()
    {
    }
}
