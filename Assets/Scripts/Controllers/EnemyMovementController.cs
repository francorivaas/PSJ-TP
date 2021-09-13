using UnityEngine;

public class EnemyMovementController : EnemyController
{
    [Header("Distances")]
    [SerializeField] private float maxDistance = 2.0f;
    [SerializeField] private float minDistance = 20.0f;

    private void Start()
    {
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
                base.FollowTarget();
                transform.position = Vector3.MoveTowards(pos, playerPos, actorStats.Speed * Time.deltaTime);
            }
        }
    }
}
