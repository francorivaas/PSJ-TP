using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IBrain
{
    [SerializeField] protected ActorStats actorStats;
    protected PlayerController player;

    private void Start()
    {
        player = GameManager.instance.Player;
    }

    private void Update()
    {
        FollowTarget();
        AttackPlayer();
    }

    public void RecognizePlayer()
    {
    }


    public virtual void FollowTarget()
    {
    }

    public virtual void AttackPlayer()
    {
    }
}
