using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleable
{
    MonoBehaviour Prefab { get; } 
    void Reset();
}
