using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBrain
{
    [SerializeField] private float speed = 2F;
    private float distance = 2;

    protected PlayerController player;
    public PlayerController Player => player;

    private void Start()
    {
        RecognizePlayer();    
    }

    public virtual void RecognizePlayer()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void FollowTarget()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);

            if (Vector3.Distance(transform.position, player.transform.position) > distance)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public virtual void AttackPlayer()
    {
    }
}
