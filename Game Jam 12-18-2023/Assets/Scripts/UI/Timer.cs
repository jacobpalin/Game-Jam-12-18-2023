using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer Bool")]
    [SerializeField] private bool countDown;

    [Header("Timer Values")]
    [SerializeField] private float gameTimer;
    private float timer;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        if (!countDown)
        {
            gameTimer = 0;
        }
        timer = gameTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!countDown)
        {
            timer += Time.deltaTime;
        }
        else if (countDown)
        {
            timer -= Time.deltaTime;
        }
        DisplayTime(timer);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
