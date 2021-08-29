using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : EnemyControl
{
    private float speed = 5.0f;
    private int damage = 10;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
        {
            Player.GetComponent<LifeController>().TakeDamage(damage);
        }
    }
}
