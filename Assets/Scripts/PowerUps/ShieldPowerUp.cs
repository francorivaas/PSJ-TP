using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUpController
{
    public override void Work()
    {
        base.Work();
        Debug.Log("you got some shield now");
    }
}
