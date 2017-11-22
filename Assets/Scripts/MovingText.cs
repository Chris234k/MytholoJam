using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingText : MonoBehaviour
{
    public Text text;

    public float distance = 0.4f;
    public float speed = 2f;
    Vector2 startPos;

    bool hasReachedScale;

    bool isSetup;

    public void Setup(string text, Color color, Vector2 worldPos)
    {
        this.startPos = worldPos;
        transform.position = startPos;
        this.text.text = text;
        this.text.color = color;

        isSetup = true;
    }

    void Update()
    {
        if ( isSetup )
        {
            if ( transform.position.y < startPos.y + distance )
            {
                Vector2 pos = transform.position;
                pos.y += speed * Time.deltaTime;

                transform.position = pos;
            }
            else
            {
                if ( hasReachedScale )
                {
                    if ( transform.localScale.x > 0 )
                    {
                        float scale = transform.localScale.x;
                        scale -= speed * 10f * Time.deltaTime;

                        transform.localScale = Vector3.one * scale;
                    }
                    else
                    {
                        isSetup = false;
                        Destroy(gameObject);
                    }
                }
                else
                {
                    // uniform scaling
                    if ( transform.localScale.x < 2 )
                    {
                        float scale = transform.localScale.x;
                        scale += speed * Time.deltaTime;

                        transform.localScale = Vector3.one * scale;
                    }
                    else
                    {
                        hasReachedScale = true;
                    }
                }
            }
        }
    }
}