using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    void Start()
    {
        RecognizePlayer();
    }

    void Update()
    {
        FollowTarget();
    }

    public override void AttackPlayer()
    {
        base.AttackPlayer();
    }
}
