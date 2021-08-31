using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory : IFactory<EnemyControl>
{
    ActorStats GetStats();
    EnemyControl GetEnemyControl();
    //void GetGraphics
}
