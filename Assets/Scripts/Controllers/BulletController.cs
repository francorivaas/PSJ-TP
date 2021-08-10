using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private float speed = 10f;
    private Weapon owner;

    private float lifetime = 3.0f;

    private Collider col;
    private Rigidbody rb;

    private void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        Initialize();
    }

    private void Initialize()
    {
        col.isTrigger = true;
        rb.isKinematic = true;
    }

    public void SetAnOwner(Weapon owner)
    {
        this.owner = owner;
    }

    private void Update()
    {
        transform.position += owner.transform.forward * speed * Time.deltaTime;
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<LifeController>()?.TakeDamage(owner.Damage);
            Destroy(gameObject, 0.1f);
        }
    }
}
