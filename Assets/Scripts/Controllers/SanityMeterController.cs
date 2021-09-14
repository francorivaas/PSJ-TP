using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityMeterController : MonoBehaviour
{
    [SerializeField] private float maxSanity = 100.0f;
    [SerializeField] private float sanityConsumption = 1.0f;
    [SerializeField] private float range = 3.0f;
    [SerializeField] private Text sanityText;
    
    private float currentSanity;
    private float time = 1.0f;

    private bool sanityCanDecrease;

    // Start is called before the first frame update
    private void Start()
    {
        currentSanity = maxSanity;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            var enemyInSight = hit.collider.gameObject.GetComponent<EnemyController>();

            if (enemyInSight != null)
                sanityCanDecrease = true;

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

        sanityText.text = currentSanity.ToString();
    }
}
