using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private LifeController life;
    private InputController input;

    private bool canCount;
    private float timeToChangeScene = 1.0f;

    private void Start()
    {
        GameManager.instance.SetPlayer(this);

        life = GetComponent<LifeController>();
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<InputController>();

        life.Death += OnDeath;
        life.GetDamage += OnGetDamage;
        input.OnMoving += OnMovingAnimation;
        canCount = false;
    }

    private void OnMovingAnimation(bool isRunning)
    {
        if (isRunning) animator.SetBool("IsRunning", true);
        else if (!isRunning) animator.SetBool("IsRunning", false);
    }

    private void OnGetDamage(int currentLife, int damage)
    {
        life.CurrentLife -= damage;
    }

    private void OnDeath()
    {
        animator.SetTrigger("IsDead");
        canCount = true;
    }

    private void Update()
    {
        if (canCount)
        {
            timeToChangeScene -= Time.deltaTime;
            if (timeToChangeScene <= 0)
            {
                canCount = false;
                GameManager.instance.LoadGameOverScene();
                life.ResetValues();
            }
        } 
    }
}
