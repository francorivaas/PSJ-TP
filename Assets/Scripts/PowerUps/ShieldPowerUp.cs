using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUpController
{
    private LifeController playerShield;

    public override void Work()
    {
        base.Work();
        //playerShield = player.GetComponent<LifeController>();
        //playerShield.HasShieldActivated = true;
        //playerShield.Shield = 50;
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject, 0.1f);
    }
}
