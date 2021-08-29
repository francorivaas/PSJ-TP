using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] private ActorStats actorStats;

    public int CurrentLife { get => _currentLife; }
    [SerializeField] private int _currentLife;

    [SerializeField] private Text lifeText;
    public bool isPlayer;

    private void Start()
    {
        _currentLife = actorStats.MaxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (_currentLife <= 0) Die();
    }

    private void Die()
    {
        if (!isPlayer) Destroy(gameObject);
    }

    private void Update()
    {
        if (isPlayer) lifeText.text = "Life: " + _currentLife;
    }
}
