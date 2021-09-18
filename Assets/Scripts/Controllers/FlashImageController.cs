using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashImageController : MonoBehaviour
{
    private float timeToFlash;
    private float lastNumber;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        PickNumber();
    }

    // Update is called once per frame
    private void Update()
    {
        timeToFlash -= Time.deltaTime;
        if (timeToFlash <= 0)
        {
            animator.SetTrigger("IsFlashing");
            PickNumber();
        }
    }

    private void PickNumber()
    {
        timeToFlash = Random.Range(10f, 45f);
    }
}
