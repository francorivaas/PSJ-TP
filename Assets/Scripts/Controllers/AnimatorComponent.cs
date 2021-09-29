using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorComponent : MonoBehaviour
{
    private Animator animator;
    private LifeController lifeController;
    private EnemyMovementController enemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lifeController = GetComponentInParent<LifeController>();
        enemy = GetComponentInParent<EnemyMovementController>();

        //Events
        lifeController.GetDamage += LifeController_GetDamage;
        lifeController.Death += LifeController_Death;
        enemy.MoveAnimation += Enemy_MoveAnimation;
    }

    private void Enemy_MoveAnimation()
    {
        animator.SetBool("IsRunning", true);
    }

    private void LifeController_GetDamage(int arg1, int arg2)
    {
        animator.SetTrigger("TakeDamage");
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    private void LifeController_Death()
    {
        throw new System.NotImplementedException();
    }
}
