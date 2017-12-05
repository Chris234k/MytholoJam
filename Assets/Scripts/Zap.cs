using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : MonoBehaviour
{
    void OnEnable()
    {
        // Do the zap
        var enemy = FindObjectOfType<Enemy>();

        if ( enemy )
        {
            transform.position = enemy.transform.position;
            Destroy(enemy.gameObject);
        }
    }
}