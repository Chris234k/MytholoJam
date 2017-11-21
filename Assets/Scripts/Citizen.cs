using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Alignment
{
    None = 0,
    Zeus,
    Poseidon,
    Athena,
}

[RequireComponent(typeof(BoxCollider2D))]
public class Citizen : MonoBehaviour
{
    BoxCollider2D localCol;

    public Alignment alignment;
    public int holiness;
    public GameObject bubble;
    public Sprite[] bubbleSprites;

    void Start()
    {
        localCol = GetComponent<BoxCollider2D>();

        int randAlign = Random.Range(1, 4);
        alignment = (Alignment)randAlign;
        bubble.GetComponent<SpriteRenderer>().sprite = bubbleSprites[randAlign - 1];

        int randHoly = Random.Range(1, 11);
        holiness = randHoly;

        moveFreq = Random.Range(1.0f, 7.0f);
        moveSpeed = Random.Range(0.2f, 1.0f);
        moveDist = Random.Range(0.2f, 0.6f);
        moveTimer = moveFreq;
    }

    float moveFreq;
    float moveTimer;
    float moveSpeed;
    float moveDist;
    bool isMoving;
    Vector3 targetPos;

    void Update()
    {
        if ( moveTimer > 0 ) // Wait to move
        {
            moveTimer -= Time.deltaTime;
        }
        else
        {
            if ( isMoving )
            {
                Vector2 distance = transform.position - targetPos;
                if ( distance.sqrMagnitude > Mathf.Epsilon * Mathf.Epsilon ) // Move toward point
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                }
                else // End movement
                {
                    moveFreq = Random.Range(1.0f, 7.0f);
                    moveSpeed = Random.Range(0.2f, 1.0f);
                    moveDist = Random.Range(0.2f, 0.6f);

                    moveTimer += moveFreq;
                    isMoving = false;
                }
            }
            else // Setup for move
            {
                bool shouldMove = ( Random.Range(1, 101) <= 90 );

                if ( shouldMove )
                {
                    targetPos.x = Random.Range(-moveDist, moveDist) + transform.position.x;
                    targetPos.y = Random.Range(-moveDist, moveDist) + transform.position.y;
                    targetPos.z = transform.position.z;

                    isMoving = true;
                }
                else
                {
                    moveTimer += moveFreq;
                }
            }
        }
    }

    void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;

        transform.position = pos;
    }

    void OnMouseUp()
    {
        // Sooo coool
        var overlapped = Physics2D.OverlapBoxAll(localCol.bounds.center, localCol.bounds.size, 0);

        for ( int i = 0; i < overlapped.Length; i++ )
        {
            overlapped[i].gameObject.SendMessage("OnCitizenDropped", this, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnMouseEnter()
    {
        bubble.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }

    void OnMouseExit()
    {
        bubble.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }
}