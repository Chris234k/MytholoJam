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
        
        for(int i = 0; i < overlapped.Length; i++)
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