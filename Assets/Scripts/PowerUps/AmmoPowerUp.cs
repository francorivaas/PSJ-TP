using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUpController
{
    public override void Work()
    {
        base.Work();
        Debug.Log("you collect some ammunition");
    }
}
