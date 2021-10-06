using System;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;
    [SerializeField] private HealthbarController healthbar;

    public int CurrentLife { get => currentLife; set => currentLife = value; }
    [SerializeField] private int currentLife;

    public event Action <int, int> GetDamage;
    public event Action Death;

    private void Start()
    {
        currentLife = actorStats.MaxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        GetDamage?.Invoke(currentLife, damage);

        currentLife -= damage;
        
        if (currentLife <= 0) Death.Invoke();
    }

    private void Update()
    {
        if (healthbar != null) healthbar.UpdateHealthbar(currentLife, actorStats.MaxLife);
    }

    public void ResetValues()
    {
        CurrentLife = actorStats.MaxLife;
        healthbar.UpdateHealthbar(currentLife, actorStats.MaxLife);
    }
}
