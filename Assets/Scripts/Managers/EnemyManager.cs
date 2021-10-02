using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy to spawn")]
    private Spawner<EnemyController> enemySpawner = new Spawner<EnemyController>();
    [SerializeField] private List<EnemyController> enemyControlList = new List<EnemyController>();

    [Header("How many enemies")]
    [SerializeField] private int enemiesToSpawn;

    [Header("Time to spawn")]
    [SerializeField] private float timeToSpawn = 10.0f;
    private float currentTimeToSpawn = 0.0f;

    private bool canSpawn;

    [SerializeField] private LayerMask enemyMask;

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        canSpawn = true;
    }
    private void Update()
    {
        Spawn();
        CheckEnemiesLeft();
    }

    private void Spawn()
    {
        if (canSpawn)
        {
            currentTimeToSpawn += Time.deltaTime;
            if (currentTimeToSpawn >= timeToSpawn)
            {
                var spawnPosition = transform.position + Random.insideUnitSphere * 10f; /*new Vector3(Random.Range(5f, 10f), 0f);*/
                Collider[] enemy = Physics.OverlapSphere(spawnPosition, 2f, enemyMask);

                var tryCounter = 0;

                while (enemy.Length >= 1 && tryCounter < 10)
                {
                    spawnPosition = transform.position + Random.insideUnitSphere * 10f; /*new Vector3(Random.Range(5f, 10f), 0f);*/
                    enemy = Physics.OverlapSphere(spawnPosition, 2f, enemyMask);
                    tryCounter++;
                }

                EnemyController e = enemySpawner.Create(enemyControlList[Random.Range(0, enemyControlList.Count)]);
                e.transform.position = spawnPosition;

                currentTimeToSpawn = 0.0f;

                enemiesToSpawn--;
            }
        }
    }

    private void CheckEnemiesLeft()
    {
        if (enemiesToSpawn <= 0)
        {
            canSpawn = false;
        }
    }
}
