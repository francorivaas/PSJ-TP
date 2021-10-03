using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private Image lifeBarImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        lifeBarImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
