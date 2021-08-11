using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected BulletController bullet;
    [SerializeField] protected Transform firePoint;

    public int MaxAmmo { get => maxAmmo; set => maxAmmo = value; }
    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }

    protected int maxAmmo = 4;
    protected int currentAmmo;

    public int Damage { get => damage; set => damage = value; }
    [SerializeField] private int damage;

    [SerializeField] protected Text ammoText;

    public virtual void Attack()
    {
    }

    protected virtual void Shoot()
    {
    }

    private void Update()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}
