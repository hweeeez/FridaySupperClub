using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public GameObject pauseMenu;
    
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
    public void startGame()
    {

        SceneManager.LoadScene("CharacterSelect");
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
