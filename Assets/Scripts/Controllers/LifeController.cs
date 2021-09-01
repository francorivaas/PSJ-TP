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

    [SerializeField] private Animator animator;
    [SerializeField] private string TakeDamageAnimation = "";

    private void Start()
    {
        //animator = GetComponentInChildren<Animator>();

        _currentLife = actorStats.MaxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentLife -= damage;

        if (!isPlayer)
        {
            animator.SetTrigger(TakeDamageAnimation);
        }

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
