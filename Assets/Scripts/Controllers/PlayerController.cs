using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Text lifeAmmountText;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Animator animator;

    public Weapon Weapon { get => weapon; set => weapon = value; }

    private LifeController life;

    private bool canCount;
    private float timeToChangeScene = 1.0f;

    private void Start()
    {
        life = GetComponent<LifeController>();
        canCount = false;
        life.Death += Life_Death;    
    }

    private void Life_Death()
    {
        animator.SetTrigger("IsDead");
        canCount = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            weapon.Shoot();

        if (Input.GetKey(KeyCode.R))
            weapon.Reload();

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
