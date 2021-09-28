using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    [SerializeField] private ShootingController playerWeapon;
    private Text thisText;

    void Start()
    {
        thisText = GetComponent<Text>();
        playerWeapon.Weapon.OnAmmoChange += Weapon_OnAmmoChange;
    }

    private void Weapon_OnAmmoChange(float arg1, float arg2)
    {
        thisText.text = arg1 + "/" + arg2;
    }
}
