using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    int Damage { get; set; }

    void Attack();
}
