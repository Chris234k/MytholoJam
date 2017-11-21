using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Canvas canvas;
    public GameObject movingTextPrefab;
    public GameObject citizenPrefab;

    public BoxCollider2D localCol;

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

            spawnTimer += spawnRate;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        if ( enemy != null )
        {
            MovingText movText = GameObject.Instantiate(movingTextPrefab, canvas.transform, false).GetComponent<MovingText>();
            movText.Setup("Ouch", collider.transform.position);

            Destroy(collider.gameObject);
        }
    }
}