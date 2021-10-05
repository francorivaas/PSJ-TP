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
    private InputController inputController;

    public bool isPlayer;

    private void Start()
    {
        #region COMPONENTS

        if (!isPlayer)
        {
            enemyController = GetComponent<EnemyController>();
            enemyMov = GetComponent<EnemyMovementController>();
        }
        else if (isPlayer)
        {
            inputController = GetComponent<InputController>();
        }
        else
            life = GetComponent<LifeController>();

        #endregion COMPONENTS


        #region EVENTS

        if (!isPlayer)
        {
            //life.GetDamage += OnGetDamage;
            enemyMov.Move += OnMove;
            enemyController.Attack += OnAttack;
        }
        if (isPlayer)
        {

        }

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
