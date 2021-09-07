using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IBrain
{
    [SerializeField] protected ActorStats actorStats;
    protected PlayerController player;
    private LifeController life;

    private void Start()
    {
        player = GameManager.instance.Player;
        life = GetComponent<LifeController>();
        life.Death += Life_Death;
    }

    private void Life_Death()
    {
        Destroy(gameObject);
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
