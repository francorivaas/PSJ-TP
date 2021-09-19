using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : PlayerController
{
    private float timeToShootAgain = 0.4f;
    private float currentTimeToShoot = 0.0f;

    public Weapon Weapon { get => weapon; }
    [SerializeField] private Weapon weapon;

    public bool CanShoot { get => canShoot; set => canShoot = value; }
    private bool canShoot;

    private void Start()
    {
        canShoot = true;

        currentTimeToShoot = timeToShootAgain;
    }

    private void Update()
    {
        if (!canShoot)
        {
            currentTimeToShoot += Time.deltaTime;
            if (currentTimeToShoot >= timeToShootAgain)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        weapon.Shoot();
    }
}
