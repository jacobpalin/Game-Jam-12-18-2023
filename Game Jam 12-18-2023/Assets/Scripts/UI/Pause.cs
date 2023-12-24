using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private bool gamePaused;
    [SerializeField] private string mainMenuSceneString;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource musicAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            gamePaused = !gamePaused;
            player.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            musicAudio.Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            pauseScreen.SetActive(false);
            gamePaused = !gamePaused;
            Time.timeScale = 1;
            player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            musicAudio.Play();
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneString);
    }
}
