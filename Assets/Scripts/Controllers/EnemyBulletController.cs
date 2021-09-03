using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float lifetime = 10;

    private PlayerController player;

    private int damage;

    private Collider col;
    private Rigidbody rb;

    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        player = GameManager.instance.Player;

        Initialize();
    }

    private void Initialize()
    {
        col.isTrigger = true;
        rb.isKinematic = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("encontré un re plasher");

            LifeController playerLife = other.GetComponent<LifeController>();
            playerLife.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
