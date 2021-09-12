using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyIA : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeToShoot = 2.0f;

    private float currentTimeToShoot = 0.0f;

    private void Start()
    {
        
    }

    void Update()
    {
        currentTimeToShoot += Time.deltaTime;
        if (currentTimeToShoot >= timeToShoot) Shoot();
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        currentTimeToShoot = 0.0f;
    }
}
