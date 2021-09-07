using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    private int damage = 10;

    private PlayerController player;
    private Collider col;
    private Rigidbody rb;

    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        player = GameManager.instance.Player;

        Initialize();
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position - transform.position;
        transform.position += playerPosition * speed * Time.deltaTime;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        col.isTrigger = true;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LifeController playerLife = other.GetComponent<LifeController>();
            playerLife.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
