using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    [SerializeField]
    private ActorStats actorStats;

    private Transform body;
    private Vector3 direction;

    public MoveCommand(Transform body, Vector3 direction, ActorStats actorStats)
    {
        this.body = body;
        this.direction = direction;
        this.actorStats = actorStats;
    }

    public void Execute()
    {
        body.position += direction * actorStats.Speed * Time.deltaTime;
    }

    public void StopExecution()
    {
        body.position = Vector3.zero;
    }
}
