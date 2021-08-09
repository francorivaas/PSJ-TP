using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected BulletController bullet;
    [SerializeField] protected Transform firePoint;

    public int Damage { get => damage; set => damage = value; }
    [SerializeField] private int damage;

    public virtual void Attack()
    {
    }

    protected virtual void Shoot()
    {
    }
}
