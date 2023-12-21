using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Bools")]
    [SerializeField] private bool countDown;
    public bool gameEnded;

    [Header("Variables")]
    [SerializeField] private float gameTimer;
    private float timer;
    [SerializeField] private string endGameTextString;
    [SerializeField] private string gradeTextString;
    [SerializeField] private float secondsForGradeA;
    [SerializeField] private float secondsForGradeB;
    [SerializeField] private float secondsForGradeC;
    [SerializeField] private float secondsForGradeD;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private TextMeshProUGUI gradeText;
    // Start is called before the first frame update
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

    // Update is called once per frame
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
            GradingSystem(timer);
        }
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
        }
        else if(secondsTaken > secondsForGradeA && secondsTaken <= secondsForGradeB)
        {
            gradeText.text = "B";
        }
        else if (secondsTaken > secondsForGradeB && secondsTaken <= secondsForGradeC)
        {
            gradeText.text = "C";
        }
        else if (secondsTaken > secondsForGradeC && secondsTaken <= secondsForGradeD)
        {
            gradeText.text = "D";
        }
        else if (secondsTaken > secondsForGradeD)
        {
            gradeText.text = "F";
        }
    }
}
