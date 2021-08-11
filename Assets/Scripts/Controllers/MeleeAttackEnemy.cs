using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackEnemy : Enemy
{
    public override void AttackPlayer()
    {
        base.AttackPlayer();

        player.GetComponent<LifeController>().TakeDamage(10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AttackPlayer();
        }
    }
}
