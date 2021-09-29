using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IBrain
{
    [SerializeField] protected ActorStats actorStats;
    protected Animator animator;

    protected PlayerController player;
    private LifeController life;

    private void Awake()
    {
        player = GameManager.instance.Player;
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        life = GetComponent<LifeController>();

        life.Death += Life_Death;
        life.GetDamage += Life_GetDamage;
    }

    private void Life_GetDamage(int currentLife, int damage)
    {
        life.CurrentLife -= damage;
        animator.SetTrigger("TakeDamage");
    }

    public virtual void Life_Death()
    {
        Destroy(gameObject, 0.5f);
    }

    private void Update()
    {
        FollowTarget();
        
    }

    public void RecognizePlayer()
    {
    }

    public virtual void FollowTarget()
    {
    }

    public virtual void AttackPlayer()
    {
        if (animator != null)
        {
            animator.SetTrigger("IsAttacking");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        int enemyLayer = collision.gameObject.layer;

        if (enemyLayer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 3f, ForceMode.Impulse);
        }
    }
}
