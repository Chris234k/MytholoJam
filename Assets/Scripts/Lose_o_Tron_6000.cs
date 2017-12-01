using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO(Chris) A temp way to lose the game and get to the game over scene.
public class Lose_o_Tron_6000 : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Backspace) )
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("game over");
        }
    }
}