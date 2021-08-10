using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUpController
{
    private Pistol pistol;

    public override void Work()
    {
        base.Work();

        pistol = player.GetComponentInChildren<Pistol>();
        if (pistol != null)
        {
            pistol.CurrentAmmo += 5;
            Debug.Log("You picked up some ammo");
        }
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject, 0.1f);
    }
}
