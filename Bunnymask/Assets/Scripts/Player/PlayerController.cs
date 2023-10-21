using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;

    [SerializeField] private float strength = 10;

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

    void Start(){
        player = GetComponent<Rigidbody2D>();   
    }

    void Update(){
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

        




        /* Screen Warp
        Vector2 newPos = transform.position;
        if(transform.position.y > screenTop){
            newPos.y = screenBottom;
        }
        if(transform.position.y < screenBottom){
            newPos.y = screenTop;
        }
        if(transform.position.x > screenRight){
            newPos.x = screenLeft;
        }
        if(transform.position.x < screenLeft){
            newPos.x = screenRight;
        }

        transform.position = newPos;*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            player.velocity = Vector3.zero;
            player.angularVelocity = 0.0f;


            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

    public void Knockback()
    {
        player.AddForce(-transform.up * strength, ForceMode2D.Impulse);
    }
}
