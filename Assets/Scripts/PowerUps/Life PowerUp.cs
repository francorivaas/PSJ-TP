using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : PowerUpController
{
    public override void Work()
    {
        base.Work();
        Debug.Log("you got some extra life now");
    }
}
