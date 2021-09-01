using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Spawner<EnemyControl> enemySpawner = new Spawner<EnemyControl>();
    [SerializeField] private List<EnemyControl> enemyControlList = new List<EnemyControl>();

    private float timeToSpawn = 5.0f;
    private float currentTimeToSpawn = 0.0f;

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
    }

    void Update()
    {
        currentTimeToSpawn += Time.deltaTime;
        if (currentTimeToSpawn >= timeToSpawn)
        {
            EnemyControl e = enemySpawner.Create(enemyControlList[Random.Range(0, enemyControlList.Count)]);
            e.transform.position = Vector3.forward * 4 + (Random.insideUnitSphere * 0.5f);
            currentTimeToSpawn = 0.0f;
        }
    }
}
