using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private int damage;

    private float timeToDamage = 1.5f;
    private float currentTimeToDamage = 0.0f;

    private bool canDamage;

    private void Start()
    {
        canDamage = true;
        currentTimeToDamage = timeToDamage;
    }

    private void Update()
    {
        currentTimeToDamage += Time.deltaTime;
        if (currentTimeToDamage >= timeToDamage)
        {
            canDamage = true;
            currentTimeToDamage = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        int layer = other.gameObject.layer;

        if (canDamage && layer == LayerMask.NameToLayer("Player"))
        {
            canDamage = false;

            LifeController pl = other.GetComponent<LifeController>();
            pl.TakeDamage(damage);
        }
    }
}
