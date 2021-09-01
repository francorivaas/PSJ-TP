using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/Weapon", order = 1)]
public class WeaponStats : ScriptableObject
{
    public int Damage => damage;
    [SerializeField] private int damage;

    public int MaxAmmo => maxAmmo;
    [SerializeField] private int maxAmmo;
}
