using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IBrain
{
    private PlayerController player;
    [SerializeField] private float speed = 2F;
    private float distance = 2;

    public virtual void FollowTarget()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);

            if (Vector3.Distance(transform.position, player.transform.position) > distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }

    public void RecognizePlayer()
    {
        player = FindObjectOfType<PlayerController>();
    }
}
