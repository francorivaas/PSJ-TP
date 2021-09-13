using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : EnemyController
{
    private float distance = 2.0f;

    private Animator animator;
    private string moveAnim = "IsRunning";

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        FollowTarget();
    }

    public override void FollowTarget()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);

            if (Vector3.Distance(transform.position, player.transform.position) > distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, actorStats.Speed * Time.deltaTime);

                if (animator != null)
                {
                    animator.SetBool(moveAnim, true);
                }
            }
        }
    }
}
