using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private LifeController life;

    private bool canCount;
    private float timeToChangeScene = 1.0f;

    private void Start()
    {
        GameManager.instance.SetPlayer(this);

        life = GetComponent<LifeController>();
        animator = GetComponentInChildren<Animator>();

        life.Death += OnDeath;
        life.GetDamage += OnGetDamage;
        canCount = false;
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
