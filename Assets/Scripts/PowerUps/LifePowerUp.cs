using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : PowerUpController
{
    private LifeController playerLife;

    public override void Work()
    {
        base.Work();

        playerLife = player.GetComponent<LifeController>();
        playerLife.CurrentLife += 10;

        Debug.Log("you got some extra life now");
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject, 0.1f);
    }
}
