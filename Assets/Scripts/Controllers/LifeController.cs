using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;

    public int CurrentLife { get => _currentLife; }
    [SerializeField] private int _currentLife;

    //public event UnityAction GetDamage;
    public event UnityAction Death;

    private void Start()
    {
        _currentLife = actorStats.MaxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentLife -= damage;
        
        if (_currentLife <= 0) 
            Death.Invoke();
    }
}
