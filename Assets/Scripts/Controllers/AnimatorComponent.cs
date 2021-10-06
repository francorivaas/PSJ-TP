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

    public bool isPlayer;

    private void Start()
    {
        #region COMPONENTS AND EVENTS

        if (!isPlayer)
        {
            enemyController = GetComponent<EnemyController>();
            enemyMov = GetComponent<EnemyMovementController>();

            enemyMov.Move += OnMove;
            enemyController.Attack += OnAttack;
        }
        else
            life = GetComponent<LifeController>();

        #endregion COMPONENTS AND EVENTS
    }
    public void OnAttack()
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
