using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Text lifeAmmountText;

    private Animator animator;
    private LifeController life;

    private bool canCount;
    private float timeToChangeScene = 1.0f;

    private void Start()
    {
        GameManager.instance.SetPlayer(this);

        life = GetComponent<LifeController>();
        animator = GetComponentInChildren<Animator>();

        canCount = false;

        life.Death += Life_Death;
        life.GetDamage += Life_GetDamage;
    }

    private void Life_GetDamage(int currentLife, int damage)
    {
        life.CurrentLife -= damage;
    }

    private void Life_Death()
    {
        animator.SetTrigger("IsDead");
        canCount = true;
    }

    private void Update()
    {
        lifeAmmountText.text = life.CurrentLife.ToString();

        if (canCount)
        {
            timeToChangeScene -= Time.deltaTime;
            if (timeToChangeScene <= 0)
            {
                canCount = false;
                GameManager.instance.LoadGameOverScene();
            }
        } 
    }
}
