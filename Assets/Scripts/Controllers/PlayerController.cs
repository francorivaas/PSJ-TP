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

    private float timeToShootAgain = 0.4f;
    private float currentTimeToShoot = 0.0f;
    private bool canShoot;

    private void Awake()
    {
    }

    private void Start()
    {
        GameManager.instance.SetPlayer(this);
        life = GetComponent<LifeController>();
        canCount = false;
        canShoot = true;

        currentTimeToShoot = timeToShootAgain;

        life.Death += Life_Death;    
    }

    private void Life_Death()
    {
        animator.SetTrigger("IsDead");
        canCount = true;
    }

    private void Update()
    {
        WeaponInputs();

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

        if (!canShoot)
        {
            currentTimeToShoot += Time.deltaTime;
            if (currentTimeToShoot >= timeToShootAgain)
            {
                canShoot = true;
            }
                
        }
        
    }

    private void WeaponInputs()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            weapon.Shoot();

            currentTimeToShoot = 0.0f;
        }

        if (Input.GetKey(KeyCode.R))
            weapon.Reload();
    }
}
