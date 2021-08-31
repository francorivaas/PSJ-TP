using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController Player => player;
    private PlayerController player;



    //---------------------------------------------------------------------------------------//
    private Spawner<EnemyControl> enemySpawner = new Spawner<EnemyControl>();
    [SerializeField] private List<EnemyControl> enemyControlList = new List<EnemyControl>();

    private float timeToSpawn = 3.0f;
    private float currentTimeToSpawn = 0.0f;
    //---------------------------------------------------------------------------------------//

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
    }

    private void Update()
    {
        currentTimeToSpawn += Time.deltaTime;
        if (currentTimeToSpawn >= timeToSpawn)
        {
            EnemyControl e = enemySpawner.Create(enemyControlList[Random.Range(0, enemyControlList.Count)]);
            e.transform.position = Vector3.forward * 4 + (Random.insideUnitSphere * 0.5f);
            currentTimeToSpawn = 0.0f;
        }
    }

    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }
}
