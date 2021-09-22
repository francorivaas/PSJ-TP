using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IGun
{
    [SerializeField] protected int damage;
    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] protected BulletController bullet;
    [SerializeField] protected Text ammoText;
    [SerializeField] protected Transform firePoint;

    protected int currentAmmo;
    public int Damage => damage;

    private bool hasAmmo;
    public bool HasAmmo { get => hasAmmo; set => hasAmmo = value; }

    private void Start()
    {
        HasAmmo = true;
        currentAmmo = weaponStats.MaxAmmo;
    }

    private void Update()
    {
        ammoText.text = currentAmmo + "/" + weaponStats.MaxAmmo;
        HasAmmo = currentAmmo <= 0 ? false : true;
    }

    public void Reload()
    {
        currentAmmo = weaponStats.MaxAmmo;
    }

    public virtual void Shoot()
    {
        
    }
}
