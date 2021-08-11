using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBrain
{
    PlayerController Player { get; }

    void RecognizePlayer();

    void FollowTarget();
}
