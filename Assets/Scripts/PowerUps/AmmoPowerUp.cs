using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUpController
{
    private Pistol pistol;
    private Shotgun shotgun;

    public override void Work()
    {
        base.Work();

        pistol = player.GetComponentInChildren<Pistol>();
        if (pistol != null)
        {
            pistol.CurrentAmmo += 5;
        }

        shotgun = player.GetComponentInChildren<Shotgun>();
        if (shotgun != null)
        {
            shotgun.CurrentAmmo += 1;
        }
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject, 0.1f);
    }
}
