using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;

    [SerializeField] Sprite ship;

    [SerializeField] private float strength = 10;

   // public bullet bulletPrefab;

    // To determine when to use Screen Wrapping
    public float screenTop; 
    public float screenBottom;
    public float screenRight;
    public float screenLeft;

    // Bullet and Attack Variables
    [SerializeField] GameObject bullet;
    public float bulletSpeed;
    public float cooldown;
    float lastShot;
    
    // Ammo System
    public int CurrentAmmo;
    public int MaxAmmo = 10;
    public bool isReloading = false;
    public float reloadDelay = 1.5f;

    // SFX
    public AudioSource shootSoundEffect;
    public AudioSource reloadSoundEffect;

    void Start(){
        player = GetComponent<Rigidbody2D>();   
        CurrentAmmo = MaxAmmo;
    }

    void Update(){
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

        // Checks for Reload when RMB is pressed
        if (Input.GetMouseButtonDown(1))
        {
            if(CurrentAmmo < 10){
                Reload();
            }
        }

        if(Input.GetMouseButtonDown(0)){
            if(isReloading || pauseMenu.GameIsPaused){
                return;
            }
            else{
                if(CurrentAmmo <= 0){
                return;
            }
            else{
                if (Time.time - lastShot < cooldown)
                {
                    return;
                }
                lastShot = Time.time;
                Shoot();
            }
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            
            player.velocity = Vector3.zero;
            player.angularVelocity = 0.0f;
            CurrentAmmo = MaxAmmo;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

    public void Knockback()
    {
        player.AddForce(-transform.up * strength, ForceMode2D.Impulse);
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate (bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed);
        Destroy(newBullet, 4f);
        CurrentAmmo--;
        Knockback();
        shootSoundEffect.Play();
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
            reloadSoundEffect.Play();
            Invoke("PerformReload", reloadDelay);
        }
    }

    private void PerformReload()
    {
        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }
}
