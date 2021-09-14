using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityMeterController : MonoBehaviour
{
    [SerializeField] private float maxSanity = 100.0f;
    [SerializeField] private float sanityConsumption = 1.0f;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private Text sanityText;
    [SerializeField] private Transform player;

    private float currentSanity;
    private float time = 1.0f;

    private bool sanityCanDecrease;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
    }

    // Update is called once per frame
    void Update()
    {
        print(sanityCanDecrease);

        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            var enemyInSight = hit.collider.gameObject.GetComponent<EnemyController>();

            if (enemyInSight != null)
            {
                print(enemyInSight);
                sanityCanDecrease = true;
            }
            else if (enemyInSight == null)
                sanityCanDecrease = false;
        }

        if (sanityCanDecrease)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                currentSanity -= sanityConsumption;
                time = 1.0f;
            }
        }

        Debug.DrawRay(player.transform.position, player.transform.forward, Color.red);
        sanityText.text = currentSanity.ToString();
    }
}
