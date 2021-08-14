using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IWeapon, IGun
{
    [SerializeField] protected BulletController bullet;
    //[SerializeField] protected Transform firePoint;

    public int MaxAmmo { get => maxAmmo; }
    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }

    [SerializeField] protected int maxAmmo;
    [SerializeField] protected int currentAmmo;

    public int Damage { get => damage; set => damage = value; }
    [SerializeField] private int damage;
    [SerializeField] protected Text ammoText;

    protected bool canShoot;

    private void Start()
    {
        canShoot = true;    
    }

    public virtual void Attack()
    {
    }

    protected virtual void Shoot()
    {
    }

    private void Update()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        canShoot = currentAmmo <= 0 ? false : true;

        if (Input.GetKey(KeyCode.F)) Debug.Log(canShoot);
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        Debug.Log("Reloading ! ! !");
    }
}
