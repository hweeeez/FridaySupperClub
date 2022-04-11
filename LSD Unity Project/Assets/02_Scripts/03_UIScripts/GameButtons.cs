using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{

    public GameObject backGround;

    private GameObject sfxGO;
    public SFXScript sfxScript;

    [Header("In-game Pause Menu & Sub Menus")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;

    [Header("Title Menu & Submenus")]
    public GameObject titleMenu;
    public GameObject tutorialMenu;
    public GameObject mainOptionsMenu;
    public GameObject creditsScreen;

    //for tutorial pages
    public GameObject[] tutorialPages;
    [SerializeField] GameObject buttonLeft;
    [SerializeField] GameObject buttonRight;
    public int currentIndex = 0;

    //title menu & submenus
    public void startGame()
    {
        sfxGO = GameObject.Find("SFX");
        sfxScript = sfxGO.GetComponent<SFXScript>();
        DontDestroyOnLoad(backGround);
        SceneManager.LoadScene("CharacterSelect");
        sfxScript.PlayButton();
    }
    public void tutorialScreen()
    {
        tutorialMenu.SetActive(true);
        buttonLeft.SetActive(false);
        titleMenu.SetActive(false);

        sfxScript.SubMenuButton();
    }
    public void optionsScreen()
    {
        mainOptionsMenu.SetActive(true);
        titleMenu.SetActive(false);

        sfxScript.SubMenuButton();
    }
    public void theCredits()
    {
        creditsScreen.SetActive(true);
        titleMenu.SetActive(false);

        sfxScript.SubMenuButton();
    }
    public void backToMain()
    {
        tutorialMenu.SetActive(false);
        mainOptionsMenu.SetActive(false);
        creditsScreen.SetActive(false);
        titleMenu.SetActive(true);
        sfxScript.BackAndResumeButton();
    }

    //tutorial submenu
    public int CurrentIndex
    {

        get
        {
            return currentIndex;
        }
        set
        {
            if (tutorialPages[currentIndex] != null)
            {
                //set the current active object to inactive, before replacing it
                GameObject activePage = tutorialPages[currentIndex];
                activePage.SetActive(false);
            }

            if (value < 0)
                currentIndex = tutorialPages.Length - 1;
            else if (value > tutorialPages.Length - 1)
                currentIndex = 0;
            else
                currentIndex = value;
            if (tutorialPages[currentIndex] != null)
            {
                GameObject aktivesObj = tutorialPages[currentIndex];
                aktivesObj.SetActive(true);
            }
        }
    }

    public void Previous(int direction)
    {
        sfxScript.BackAndResumeButton();

        if (direction == 0)
            CurrentIndex--;

        if (CurrentIndex <= 3)
        {
            buttonRight.SetActive(true);
        }

        if (CurrentIndex <= 0)
        {
            buttonLeft.SetActive(false);
        }
    }

    public void Next(int direction)
    {
        sfxScript.InGameMenuButtons();

        if (direction >= 0)
            CurrentIndex++;

        if (CurrentIndex >= 3)
        {
            buttonRight.SetActive(false);
        }

        if (CurrentIndex >= 1)
        {
            buttonLeft.SetActive(true);
        }

    }

    //in-game menu / submenu
    public void openPause()
    {
        sfxScript.InGameMenuButtons();

        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void continueGame()
    {
        sfxScript.BackAndResumeButton();

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void restartGame()
    {
        sfxScript.PlayButton();

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayableTest01");
    }
    public void openOptions()
    {
        sfxScript.SubMenuButton();

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void optionsBack()
    {
        sfxScript.BackAndResumeButton();

        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void openControls()
    {
        sfxScript.InGameMenuButtons();

        controlsMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void controlsBack()
    {
        sfxScript.BackAndResumeButton();

        controlsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    //Pause Menu & Vic screen

    public void QuitToMainMenu()
    {
        sfxScript.BackAndResumeButton();

        SceneManager.LoadScene("TitleMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
