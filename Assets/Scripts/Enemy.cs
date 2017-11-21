using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    float speed;

    bool isSetup;

    float endScale;

    public BoxCollider2D localCol;

    public void Setup(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;

        endScale = transform.localScale.x * 1.5f;

        isSetup = true;
    }

    void Update()
    {
        if ( isSetup )
        {
            Vector3 newPos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            newPos.z = transform.position.z;

            transform.position = newPos;
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
        while(transform.localScale.x < endScale)
        {
            float scale = transform.localScale.x;
            scale += (scale * 2.5f) * Time.deltaTime;
            transform.localScale = Vector3.one * scale;

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}