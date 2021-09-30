using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorComponent : MonoBehaviour
{
    [Header("Animations")]

    [SerializeField] private Animator animator;
    [SerializeField] private string getDamageAnimationName;
    [SerializeField] private string moveAnimationName;
    [SerializeField] private string attackAnimationName;

    [Header("Components")]

    [SerializeField] private EnemyController enemyController;
    [SerializeField] private LifeController life;
    [SerializeField] private EnemyMovementController enemyMov;

    private void Start()
    {
        //Events
        life.GetDamage += OnGetDamage;
        life.Death += OnDeath;
        enemyMov.Move += OnMove;
        enemyController.Attack += OnAttack;
    }

    private void OnAttack()
    {
        animator.SetTrigger(attackAnimationName);
    }

    private void OnMove()
    {
        animator.SetBool(moveAnimationName, true);
    }

    private void OnGetDamage(int arg1, int arg2)
    {
        animator.SetTrigger(getDamageAnimationName);
    }

    private void OnDeath()
    {
        //TODO: DeathAnim;
    }
}
