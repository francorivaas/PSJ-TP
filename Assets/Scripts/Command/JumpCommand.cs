using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private Rigidbody body;
    private ForceMode forceMode;
    private Vector3 force;
    private float impulse;

    public JumpCommand(Rigidbody body, Vector3 force, float impulse, ForceMode forceMode)
    {
        this.body = body;
        this.force = force;
        this.impulse = impulse;
        this.forceMode = forceMode;
    }

    public void Execute()
    {
        body.AddForce(force * impulse, forceMode);
    }
}
