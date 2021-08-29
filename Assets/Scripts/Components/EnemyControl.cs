using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour, IBrain
{
    [SerializeField] private ActorStats actorStats;
    private float distance = 2;

    public PlayerController Player { get => player; set => player = value; }
    private PlayerController player;

    private void Start()
    {
        RecognizePlayer();
    }

    public void RecognizePlayer()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        FollowTarget();
        AttackPlayer();
    }

    public void FollowTarget()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);

            if (Vector3.Distance(transform.position, player.transform.position) > distance)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, actorStats.Speed * Time.deltaTime);
        }
    }

    public virtual void AttackPlayer()
    {
    }

}
