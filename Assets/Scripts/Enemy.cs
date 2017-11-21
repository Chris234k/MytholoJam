using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpawnZone spawnZone;
    Transform target;
    float speed;
    bool isSetup;
    float endScale;

    public BoxCollider2D localCol;

    public void Setup(SpawnZone spawnZone, float speed)
    {
        this.spawnZone = spawnZone;
        this.speed = speed;

        target = GetTarget(spawnZone);
        endScale = transform.localScale.x * 1.5f;

        isSetup = true;
    }

    private Transform GetTarget(SpawnZone spawnZone)
    {
        Bounds spawnBounds = spawnZone.localCol.bounds;

        // TODO(Chris) Only allow collison on citizen layer
        var hitObjs = Physics2D.OverlapBoxAll(spawnBounds.center, spawnBounds.size, 0);

        // TODO(Chris) Performance ??
        int citizensCount = 0;
        for ( int i = 0; i < hitObjs.Length; i++ )
        {
            if ( hitObjs[i].GetComponent<Citizen>() )
            {
                citizensCount++;
                break;
            }
        }

        if ( citizensCount > 0 )
        {
            Citizen citizen;
            do
            {
                int randIndex = Random.Range(0, hitObjs.Length);
                citizen = hitObjs[randIndex].GetComponent<Citizen>();
            }
            while ( citizen == null );

            return citizen.transform;
        }
        else
        {
            Debug.LogWarning("No citizens in spawn, I die");
            StartCoroutine(DeathRoutine());
            return transform;
        }
    }

    void Update()
    {
        if ( isSetup )
        {
            if ( target == null ) // Targets are citizens; citizens are destroyed when added to a city
            {
                target = GetTarget(spawnZone);
            }

            Vector2 distance = transform.position - target.position;
            if ( distance.sqrMagnitude > Mathf.Epsilon * Mathf.Epsilon ) // Move toward point
            {
                Vector3 newPos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                newPos.z = transform.position.z;

                transform.position = newPos;
            }
            else
            {
                Destroy(target.gameObject);
                StartCoroutine(DeathRoutine());
            }
            
        }
    }

    void OnMouseDown()
    {
        isSetup = false;
        localCol.enabled = false;
        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine()
    {
        while ( transform.localScale.x < endScale )
        {
            float scale = transform.localScale.x;
            scale += ( scale * 2.5f ) * Time.deltaTime;
            transform.localScale = Vector3.one * scale;

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}