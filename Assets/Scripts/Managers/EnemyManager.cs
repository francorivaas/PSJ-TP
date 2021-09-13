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
                EnemyController e = enemySpawner.Create(enemyControlList[Random.Range(0, enemyControlList.Count)]);
                e.transform.position = transform.position; /*Vector3.forward + (Random.insideUnitSphere * 0.5f);*/
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
