using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackEnemy : Enemy
{
    private int damage = 10;

    public override void AttackPlayer()
    {
        base.AttackPlayer();
        player.GetComponent<LifeController>().TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AttackPlayer();
            print("attascking player");
        }
    }
}
