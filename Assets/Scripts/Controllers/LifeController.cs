using System;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;

    public int CurrentLife { get => _currentLife; set => _currentLife = value; }
    [SerializeField] private int _currentLife;

    public event Action<int, int> GetDamage;
    public event Action Death;

    private void Start()
    {
        _currentLife = actorStats.MaxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        GetDamage?.Invoke(_currentLife, damage);

        _currentLife -= damage;
        
        if (_currentLife <= 0) 
            Death.Invoke();
    }
}
