using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public GameObject backGround;

    [Header("In-game Pause Menu & Sub Menus")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;

    [Header("Title Menu & Submenus")]
    public GameObject titleMenu;
    public GameObject tutorialMenu;
    public GameObject mainOptionsMenu;
    public GameObject creditsScreen;

    //title menu & submenus
    public void startGame()
    {
        DontDestroyOnLoad(backGround);
        SceneManager.LoadScene("CharacterSelect");
    }
    public void tutorialScreen()
    {
        tutorialMenu.SetActive(true);
        titleMenu.SetActive(false);
    }
    public void optionsScreen()
    {
        mainOptionsMenu.SetActive(true);
        titleMenu.SetActive(false);
    }
    public void theCredits()
    {
        creditsScreen.SetActive(true);
        titleMenu.SetActive(false);
    }
    public void backToMain()
    {
        tutorialMenu.SetActive(false);
        mainOptionsMenu.SetActive(false);
        creditsScreen.SetActive(false);
        titleMenu.SetActive(true);
    }

    //in-game menu / submenu
    public void openPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void continueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void restartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayableTest01");
    }
    public void openOptions()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void optionsBack()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void openControls()
    {
        controlsMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void controlsBack()
    {
        controlsMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
