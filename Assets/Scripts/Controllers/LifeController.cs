using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxLife = 100;
    [SerializeField] private int currentLife;
    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int CurrentLife { get => currentLife; set => currentLife = value; }

    private void Start()
    {
        currentLife = maxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
            Debug.Log("im" + name + "and my life is " + currentLife);
        }

        else if (currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && currentLife > 0)
        {
            TakeDamage(10);
        }



        else if(Input.GetKeyDown(KeyCode.Space) && currentLife <= 0)
            Debug.Log("health is already zero ! ! !");
    }
}
