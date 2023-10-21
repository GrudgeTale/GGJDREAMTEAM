using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroidSpawner : MonoBehaviour
{
    public BigAsteroid BigasteroidPrefab;
    [SerializeField]
    private float trajectoryVariance = 15.0f;
    [SerializeField]
    private float spawnRate = 3.0f;
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
        BigasteroidPrefab.maxSize = 6.0f;

        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Update()
    {

        if (BigasteroidPrefab.maxSize != 8.0f) 
        {
            if (currentTime < minuteTime)
            {
                currentTime += 1 * Time.deltaTime;
            }
            else
            {
                BigasteroidPrefab.maxSize += 1;
                currentTime = 0f;
            }

        }
    }
    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {

            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;


            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            BigAsteroid asteroid = Instantiate(this.BigasteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            //   asteroid.SetTrajectory(-spawnDirection);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
