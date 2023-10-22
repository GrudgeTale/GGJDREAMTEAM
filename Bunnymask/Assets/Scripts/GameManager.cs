using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController player;

    public float respawnTime = 3.0f;

    public float respawnInvulnerablitiyTime = 3.0f;

    public int lives = 3;

    public int Scoring = 10;

    public int highScore;

    public float time;

    public bool dead;

    public void Start(){
        highScore = PlayerPrefs.GetInt("highScore", 0);
        dead = false;
    }

    public void Update(){
        if(lives > 0){
            time += 1 * Time.deltaTime;
        }
        else{
            if(!dead){
                if(highScore < Scoring){
                    PlayerPrefs.SetInt("highScore", Scoring);
                }
                print(Scoring);
                print(highScore);
            }
            dead = true;

        }
    }

    public void PlayerDied()
    {
        this.lives--;

        if(this.lives <= 0)
        {
            
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }

        
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerablitiyTime);

    }
    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.Scoring += 100;
    }
    public void BigAsteroidDestroyed(BigAsteroid bigasteroid)
    {
        this.Scoring += 200;
    }

}
