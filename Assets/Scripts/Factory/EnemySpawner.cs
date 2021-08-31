using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<EnemyControl>, IEnemyFactory
{
    //public override EnemyControl Create(EnemyControl prefab)
    //{
    //    EnemyControl eC = base.Create(prefab);
    //}

    public EnemyControl GetEnemyControl()
    {
        throw new System.NotImplementedException();
    }

    public ActorStats GetStats()
    {
        throw new System.NotImplementedException();
    }
}
