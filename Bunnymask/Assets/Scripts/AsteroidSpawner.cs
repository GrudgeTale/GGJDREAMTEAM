using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    [SerializeField]
    private float trajectoryVariance = 15.0f;
    [SerializeField]
    private float spawnRate = 2.0f;
    [SerializeField]
    private float spawnDistance = 15.0f;
    [SerializeField]
    private int spawnAmount = 1;
    [SerializeField]
    private float currentTime = 0f;
    [SerializeField]
    private float minuteTime = 10f;

    private void Start()
    {
        // it will call every 2 seconds
        asteroidPrefab.nmaxSize = 2.0f;

        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Update()
    {
        if (asteroidPrefab.nmaxSize != 4.0f)
        {

            if (currentTime < minuteTime)
            {
                currentTime += 1 * Time.deltaTime;
            }
            else
            {
                asteroidPrefab.nmaxSize += 1;
                currentTime = 0f;
            }
        }
    }
    private void Spawn()
    {
        for(int i = 0; i < this.spawnAmount; i++)
        {

            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;


             float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
             Quaternion rotation = Quaternion.AngleAxis(variance,Vector3.forward);
            
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.nsize = Random.Range(asteroid.nminSize, asteroid.nmaxSize);
         //   asteroid.SetTrajectory(-spawnDirection);
           asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
