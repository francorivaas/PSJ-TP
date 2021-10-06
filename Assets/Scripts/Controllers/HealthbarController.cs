using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private Image lifeBarImage;

    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        lifeBarImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
