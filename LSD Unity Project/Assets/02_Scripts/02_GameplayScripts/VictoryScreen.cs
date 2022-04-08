using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScreen : MonoBehaviour
{

    public static GameObject winner;

    bool vicScreen;

    // Start is called before the first frame update
    void Start()
    {
        vicScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //bool vicScreen = false;

        if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        {
            print("EndGame");
            winner = GameObject.FindGameObjectWithTag("Player");
            print(winner.name);
            if (!vicScreen)
            {
                Invoke("LoadVictoryScreen", 1.5f);
                vicScreen = true;
            }
        }

    }

    void LoadVictoryScreen()
    {
        SceneManager.LoadScene("VictoryScreen");
        DontDestroyOnLoad(this);
    }

}
