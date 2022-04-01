using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public GameObject backGround;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;
    
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
    public void startGame()
    {
        DontDestroyOnLoad(backGround);
        SceneManager.LoadScene("CharacterSelect");
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
