using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 40f;
    public float spawnRateIncrement = 1f;
    public float xlimit;
    public float maxTimeLife = 4f;

    private float spawnNext = 0;


    void Start()
    {
    }

    void Update()
    {
        if (Time.time > spawnNext) {
            spawnNext = Time.time + 60 /spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;
            float rand = Random.Range(-xlimit, xlimit);
            Vector3 spawnPosition = new Vector2(rand,8f);
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Destroy(meteor, maxTimeLife);
        }
    }
}
