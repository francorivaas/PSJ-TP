using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyIA : EnemyController
{
    [SerializeField] private GameObject projectile;
    private float timeToShoot = 2.0f;
    private float currentTimeToShoot = 0.0f;

    private void Start()
    {
        currentTimeToShoot = timeToShoot;
        RecognizePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeToShoot += Time.deltaTime;
        if (currentTimeToShoot >= timeToShoot)
        {
            AttackPlayer();
        }
    }

    public override void AttackPlayer()
    {
        if (player != null)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            currentTimeToShoot = 0.0f;
            base.AttackPlayer();
        }
    }
}
