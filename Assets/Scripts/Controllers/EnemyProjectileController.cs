using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : EnemyControl
{
    private float speed = 5.0f;
    private int damage = 10;

    void Update()
    {
        if (player != null)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            player.GetComponent<LifeController>().TakeDamage(damage);
        }
    }
}
