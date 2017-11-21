using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float enemySpeed;
    public SpawnZone spawnZone;
    public GameObject enemyPrefab;

    public float spawnRate = 1.0f;
    float spawnTimer;

    void Start()
    {
        spawnTimer = spawnRate;
    }

    void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            Enemy enemy = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>();

            enemy.Setup(spawnZone, enemySpeed);

            spawnTimer += spawnRate;
        }
    }
}
