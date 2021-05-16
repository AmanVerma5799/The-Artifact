using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject wolfPrefab, wolfEaterPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int eaterWolfChance = 3;
    [SerializeField] private float spawnDelay = 12f;
    [SerializeField] private float delayReductionPerWolf = 1f;
    [SerializeField] private float minSpawnDelay = 3.5f ;

    private float currentSpawnTime;
    private float timer;

    void Start()
    {
        currentSpawnTime = spawnDelay;
        timer = Time.time;
    }

    void Update()
    {
        if(Time.time > timer)
        {
            SpawnWolf();

            currentSpawnTime -= delayReductionPerWolf;

            if(currentSpawnTime <= minSpawnDelay)
            {
                currentSpawnTime = minSpawnDelay;
            }

            timer = Time.time + currentSpawnTime;
        }
    }

    void SpawnWolf()
    {
        if(Random.Range(1, 11) > eaterWolfChance)
        {
            Instantiate(wolfPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
        else
        {
            Instantiate(wolfEaterPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
