using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon, IGun
{
    [SerializeField] private int bulletSpread = 5;

    public int MaxAmmo { get => maxAmmo; set => maxAmmo = value; }
    public int CurrentAmmo { get; set; }

    private int maxAmmo = 4;
    [SerializeField] private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;    
    }

    public override void Attack()
    {
        currentAmmo--;

        for (int i = 0; i < bulletSpread; i++)
        {
            BulletController b = Instantiate(bullet, transform.position + Random.insideUnitSphere * 1, Quaternion.identity);
            b.SetAnOwner(this);
        }
    }

    public virtual void Reload()
    {
        if (currentAmmo <= 0)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
        }
    }
}
