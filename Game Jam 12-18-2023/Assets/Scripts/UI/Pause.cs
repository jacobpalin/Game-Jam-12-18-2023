using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private bool gamePaused;
    [SerializeField] private string mainMenuSceneString;

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            gamePaused = !gamePaused;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            pauseScreen.SetActive(false);
            gamePaused = !gamePaused;
            Time.timeScale = 1;
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneString);
    }
}
