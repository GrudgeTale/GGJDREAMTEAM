using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRate = 2.0f;

    public int spawnAmount = 1;
    
    private void Start()
    {
        // it will call every 2 seconds
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }
    private void Spawn()
    {
        for(int i = 0; i < this.spawnAmount; i++)
        {

        }
    }
}
