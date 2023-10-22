using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float bulletSpeed;
    public float cooldown;
    float lastShot;
    public int CurrentAmmo;
    public int MaxAmmo = 6;
    public bool isReloading = false;
    public float reloadDelay = 1.5f;
    public PlayerController move;

    // SFX
    [SerializeField] private AudioSource shootSoundEffect;

    void Start()
    {
        CurrentAmmo = MaxAmmo;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0 && !isReloading)
        {
            if (Time.time - lastShot < cooldown)
            {
                return;
            }
            lastShot = Time.time;
            Shoot();
            try{
                if(CurrentAmmo >= 0){
                    move.Knockback();
                    shootSoundEffect.Play();
                }
            }
            catch{

            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(CurrentAmmo < 6){
                Reload();
            }
        }
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed);
        Destroy(newBullet, 4f);
        CurrentAmmo--;

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