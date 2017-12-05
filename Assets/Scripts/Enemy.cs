using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpawnZone spawnZone;
    Transform target;
    List<GameObject> targetCities;
    float speed;
    bool isSetup;
    bool hasAttacked;
    float endScale;

    public int power;
    public BoxCollider2D localCol;

	public void Setup(SpawnZone spawnZone, float speed, List<GameObject> targetCities)
    {
        this.spawnZone = spawnZone;
        this.speed = speed;
        this.targetCities = targetCities;

        power = Random.Range(1, 4);

        target = GetTarget(spawnZone);
        endScale = transform.localScale.x * 1.5f;

        isSetup = true;
    }

    private Transform GetTarget(SpawnZone spawnZone)
    {
    	if (targetCities.Count > 0)
		{
			GameObject targetCity = targetCities[Random.Range(0, targetCities.Count)];
			return targetCity.transform;
    	}
    	else
    	{
			StartCoroutine(DeathRoutine());
    		return transform;
    	}

        /*Bounds spawnBounds = spawnZone.localCol.bounds;

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
        }*/
    }

    void Update()
    {
        if ( isSetup )
        {
            if ( target == null || !target.gameObject.activeSelf) // Targets are citizens; citizens are destroyed when added to a city
            {
            	targetCities.Remove(target.gameObject);
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
            	if (!hasAttacked)
				{
            		StartCoroutine(DeathRoutine());
            	}

            	hasAttacked = true;
            }
            
        }
    }

    void OnMouseDown()
    {
        //isSetup = false;
        //localCol.enabled = false;
        //StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine()
    {
        while ( transform.localScale.x < endScale )
        {
            float scale = transform.localScale.x;
            scale += ( scale * 2 ) * Time.deltaTime;
            transform.localScale = Vector3.one * scale;

            yield return new WaitForEndOfFrame();
		}

		if (target.gameObject.activeSelf)
		{
			target.gameObject.SendMessage("OnEnemyAttack", this, SendMessageOptions.DontRequireReceiver);
		}

		Destroy(gameObject);
    }
}