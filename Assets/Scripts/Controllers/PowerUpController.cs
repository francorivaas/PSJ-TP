using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class PowerUpController : MonoBehaviour, IInteractable
{
    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();    
    }

    private void Start()
    {
        col.isTrigger = true;        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Work();
            Destroy();
        }
    }

    public virtual void Work()
    {
    }

    protected virtual void Destroy()
    {
    }
}
