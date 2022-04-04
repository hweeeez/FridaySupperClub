using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScreen : MonoBehaviour
{

    public static GameObject winner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool vicScreen = false;
        if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        {
            print("EndGame");
            winner = GameObject.FindGameObjectWithTag("Player");
            print(winner.name);
            if (!vicScreen)
            {
                SceneManager.LoadScene("VictoryScreen");
                DontDestroyOnLoad(this);
                vicScreen = true;
            }
        }

    }
}
