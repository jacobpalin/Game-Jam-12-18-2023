using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string mainLevelString;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject mainMenu;

    private void Start()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainLevelString);
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}