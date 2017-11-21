using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject gameOver;
    public Text timerText;
    WaitForSeconds oneSecond;

    float gameDuration = 30f;
    float timer;

    void Awake()
    {
        gameOver.SetActive(false);
    }

    void Start()
    {
        oneSecond = new WaitForSeconds(1f);

        timer = gameDuration;
        StartCoroutine(TimerRoutine());
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    IEnumerator TimerRoutine()
    {
        while ( timer > 0 )
        {
            timerText.text = timer.ToString("0");
            yield return oneSecond;
        }

        gameOver.SetActive(true);
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main.unity");
    }
}