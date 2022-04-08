using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScreen : MonoBehaviour
{

    public static GameObject winner;

    public GameObject firstPodium;

    static Scene currentScene;

    bool vicScreen;
    bool loadScene;

    public GameObject[] spawnPoints;
    public GameObject selectedPoint;
    int index;

    void Start()
    {
        vicScreen = false;
        currentScene = SceneManager.GetActiveScene();

        //SPAWN POINTS FOR OTHER CHARACTERS
        spawnPoints = GameObject.FindGameObjectsWithTag("VicScreenPoints");
        index = Random.Range(0, spawnPoints.Length);
        selectedPoint = spawnPoints[index];

        if (!loadScene)
        {
            SceneManager.LoadSceneAsync("VictoryScreen", LoadSceneMode.Additive);

            loadScene = true;
        }
    }

    void Update()
    {
        //bool vicScreen = false;

        if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        {
            print("EndGame");
            winner = GameObject.FindGameObjectWithTag("Player");
            //DontDestroyOnLoad(winner);
            print(winner.name);
            if (!vicScreen)
            {
                Invoke("LoadVictoryScreen", 2f);
                vicScreen = true;
            }
        }
    }

    void LoadVictoryScreen()
    {
        firstPodium = GameObject.Find("1stPlace");
        SceneManager.MoveGameObjectToScene(winner, SceneManager.GetSceneByName("VictoryScreen"));
        DontDestroyOnLoad(this);

        winner.transform.position = firstPodium.transform.position;
        SceneManager.UnloadSceneAsync(currentScene);
    }

}
