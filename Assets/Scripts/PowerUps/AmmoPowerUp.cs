using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUpController
{
    private Weapon weapon;

    private void Start()
    {
        
    }

    public override void Work()
    {
        base.Work();
        player.Weapon.CurrentAmmo += 5;
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject, 0.1f);
    }
}
