using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 0)]
public class ActorStats : ScriptableObject
{
    public int MaxLife { get => maxLife; }
    [SerializeField] private int maxLife = 50;

    public float Speed { get => speed; set => speed = value; }
    [SerializeField] private float speed;
}
