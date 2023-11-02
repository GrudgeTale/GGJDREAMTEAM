using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction;
        rb = this.GetComponent<Rigidbody2D>();   
        try{
            if(player != null){
                player = GameObject.Find("Player").transform;
            }
        }
        catch{
            direction = transform.position;
        }
        direction = player.position - transform.position;
        transform.up = direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate(){
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
