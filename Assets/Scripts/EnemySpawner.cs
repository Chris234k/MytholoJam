﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float enemySpeed;
    public SpawnZone spawnZone;
    public GameObject enemyPrefab;
	public List<GameObject> targetCities;

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
        else if (targetCities.Count > 0)
        {
			for (int i = targetCities.Count - 1; i >= 0; i--)
			{
				if (!targetCities[i].activeSelf)
				{
					targetCities.Remove(targetCities[i]);
				}
			}

            Enemy enemy = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>();
            enemy.Setup(spawnZone, enemySpeed, targetCities);

            spawnTimer += spawnRate;
        }
    }
}
