using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class PowerUpController : MonoBehaviour, IInteractable
{
    private Collider col;
    protected PlayerController player;

    private void Awake()
    {
        col = GetComponent<Collider>();    
        player = FindObjectOfType<PlayerController>();
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
