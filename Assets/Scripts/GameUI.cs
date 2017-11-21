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

        // TODO(Chris) Gross? Or just easy and nice enough?
        var spawner = FindObjectOfType<SpawnZone>();
        spawner.gameObject.SetActive(false);

        var citizens = FindObjectsOfType<Citizen>();
        for(int i = 0; i < citizens.Length; i++)
        {
            citizens[i].gameObject.SetActive(false);
        }

        gameOver.SetActive(true);
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
}