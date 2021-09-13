using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : EnemyController
{
    [Header("Distances")]
    [SerializeField] private float maxDistance = 2.0f;
    [SerializeField] private float minDistance = 20.0f;

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

            Vector3 pos = transform.position;
            Vector3 playerPos = player.transform.position;
            float distanceBtw = Vector3.Distance(pos, playerPos);

            if (distanceBtw > maxDistance && distanceBtw < minDistance)
            {
                pos = Vector3.MoveTowards(pos, playerPos, actorStats.Speed * Time.deltaTime);

                if (animator != null)
                {
                    animator.SetBool(moveAnim, true);
                }
            }
        }
    }
}
