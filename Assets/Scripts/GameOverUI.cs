using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text score;

    void Start()
    {
        score.text = string.Format("Athena: {0}\nPoseidon: {1}\nZeus: {2}",
            City.scores[Alignment.Athena],
            City.scores[Alignment.Poseidon],
            City.scores[Alignment.Zeus]);
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
}