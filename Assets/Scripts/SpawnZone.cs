﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Canvas canvas;
    public GameObject movingTextPrefab;
    public GameObject citizenPrefab;

    public BoxCollider2D localCol;

    int spawnCount;
    public float spawnRate = 1f;
    float spawnTimer;

    void Update()
    {
        if ( spawnTimer > 0 )
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            float randx = Random.Range(localCol.bounds.min.x, localCol.bounds.max.x);
            float randy = Random.Range(localCol.bounds.min.y, localCol.bounds.max.y);

            GameObject.Instantiate(citizenPrefab, new Vector3(randx, randy, citizenPrefab.transform.position.z), Quaternion.identity);

            spawnCount++;
            if(spawnCount % 4 == 0)
            {
                spawnRate *= 0.95f;
                spawnRate = Mathf.Max(spawnRate, 0.8f);
            }

            spawnTimer += spawnRate;
        }
    }
}