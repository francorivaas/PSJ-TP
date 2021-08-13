using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUpController
{
    private float delayToDestroy = 0.1f;
    private int ammoPlus = 1;

    public override void Work()
    {
        base.Work();
        if (player.Weapon.CurrentAmmo < player.Weapon.MaxAmmo)
        {
            player.Weapon.CurrentAmmo += ammoPlus;
        }
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject, delayToDestroy);
    }
}
