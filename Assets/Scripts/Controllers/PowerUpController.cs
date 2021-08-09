using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PowerUpController : MonoBehaviour, IInteractable
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
        }
    }

    public virtual void Work()
    {
    }
}
