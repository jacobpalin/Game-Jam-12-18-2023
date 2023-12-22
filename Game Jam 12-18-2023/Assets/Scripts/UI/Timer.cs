using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Bools")]
    [SerializeField] private bool countDown;
    public bool gameEnded;
    
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private TextMeshProUGUI gradeText;

    [Header("Other")]
    [SerializeField] private float gameTimer;
    private float timer;
    [SerializeField] private string endGameTextString;
    [SerializeField] private string gradeTextString;
    [SerializeField] private float secondsForGradeA;
    [SerializeField] private float secondsForGradeB;
    [SerializeField] private float secondsForGradeC;
    [SerializeField] private float secondsForGradeD;

    void Start()
    {
        finalTimeText.gameObject.SetActive(false);
        gradeText.gameObject.SetActive(false);
        if (!countDown)
        {
            gameTimer = 0;
        }
        timer = gameTimer;
    }

    void Update()
    {
        if (!gameEnded)
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
        else if (gameEnded)
        {
            timerText.gameObject.SetActive(false);
            gradeText.gameObject.SetActive(true);
            finalTimeText.gameObject.SetActive(true);
            finalTimeText.text = endGameTextString + timerText.text;
        }
        GradingSystem(timer);
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GradingSystem(float secondsTaken)
    {
        if(secondsTaken <= secondsForGradeA)
        {
            gradeText.text = "A";
            timerText.color = Color.cyan;
            gradeText.color = Color.cyan;
        }
        else if(secondsTaken > secondsForGradeA && secondsTaken <= secondsForGradeB)
        {
            gradeText.text = "B";
            timerText.color = Color.green;
            gradeText.color = Color.green;
        }
        else if (secondsTaken > secondsForGradeB && secondsTaken <= secondsForGradeC)
        {
            gradeText.text = "C";
            timerText.color = Color.yellow;
            gradeText.color = Color.yellow;
        }
        else if (secondsTaken > secondsForGradeC && secondsTaken <= secondsForGradeD)
        {
            gradeText.text = "D";
            timerText.color = Color.red;
            gradeText.color = Color.red;
        }
        else if (secondsTaken > secondsForGradeD)
        {
            gradeText.text = "F";
            timerText.color = Color.red;
            gradeText.color = Color.red;
        }
    }
}