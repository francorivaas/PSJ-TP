using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    int MaxAmmo { get; set; }
    int CurrentAmmo { get; set; }

    void Reload();
}
