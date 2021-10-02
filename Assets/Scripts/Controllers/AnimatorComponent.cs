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

    private EnemyController enemyController;
    private LifeController life;
    private EnemyMovementController enemyMov;

    private void Start()
    {
        #region COMPONENTS
        //Components
        enemyController = GetComponent<EnemyController>();
        life = GetComponent<LifeController>();
        enemyMov = GetComponent<EnemyMovementController>();
        #endregion COMPONENTS

        #region EVENTS
        //Events
        life.GetDamage += OnGetDamage;
        enemyMov.Move += OnMove;
        enemyController.Attack += OnAttack;
        #endregion EVENTS
    }

    private void OnAttack()
    {
        animator.SetTrigger(attackAnimationName);
    }

    private void OnMove()
    {
        animator.SetBool(moveAnimationName, true);
    }

    private void OnGetDamage(int currentLife, int damage)
    {
        animator.SetTrigger(getDamageAnimationName);
    }
}
