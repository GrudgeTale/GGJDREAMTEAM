using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float bulletSpeed;
    public float cooldown;
    float lastShot;
    public int CurrentAmmo;
    public int MaxAmmo = 10;
    public bool isReloading = false;
    public float reloadDelay = 1.5f;
    public PlayerController move;

    // SFX
    public AudioSource shootSoundEffect;

    void Start()
    {
        CurrentAmmo = MaxAmmo;

    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0 && !isReloading)
        {
            
            Shoot();

            try{
                if(CurrentAmmo >= 0){
                    move.Knockback();
                    shootSoundEffect.Play();
                }
            }
            catch{

            }
            
        }*/

        if (Input.GetMouseButtonDown(1))
        {
            if(CurrentAmmo < 10){
                Reload();
            }
        }
    }

    public void Shoot()
    {
        // CurrentAmmo--;

        if (CurrentAmmo <= 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (!isReloading)
        {
            isReloading = true;
            Invoke("PerformReload", reloadDelay);
        }
    }

    private void PerformReload()
    {
        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }
}