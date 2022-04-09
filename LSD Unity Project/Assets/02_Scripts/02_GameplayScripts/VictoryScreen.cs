using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScreen : MonoBehaviour
{

    public GameObject winner;
    public List<GameObject> players;
    public GameObject firstPodium;

    static Scene currentScene;

    public bool vicScreen = false;
    bool loadScene;
    public static bool endGame = false;
    public GameObject[] spawnPoints;
    public GameObject selectedPoint;
    int index;

    void Start()
    {
        vicScreen = false;
        currentScene = SceneManager.GetActiveScene();

        //SPAWN POINTS FOR OTHER CHARACTERS
       // spawnPoints = GameObject.FindGameObjectsWithTag("VicScreenPoints");
    /*    index = Random.Range(0, spawnPoints.Length);
        selectedPoint = spawnPoints[index];*/

 /*       if (!loadScene)
        {
            SceneManager.LoadSceneAsync("VictoryScreen", LoadSceneMode.Additive);

            loadScene = true;
        }*/
      /*  players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
       */
    }

    void Update()
    {
        //bool vicScreen = false;
      
        if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        {
            endGame = true;
            print("EndGame");
            winner = GameObject.FindGameObjectWithTag("Player");
            //DontDestroyOnLoad(winner);
            print(winner.name);
            PlayerPrefs.SetString("Winner", winner.name);
            if (!vicScreen)
            {
                Invoke("LoadVictoryScreen", 2f);
                vicScreen = true;
            }
        }
     
           
        }
    

    void LoadVictoryScreen()
    {/*for(int i = 0; i < players.Count; i++)
        {
            DontDestroyOnLoad(players[i]);
        }*/
        /*        firstPodium = GameObject.Find("1stPlace");
                SceneManager.MoveGameObjectToScene(winner, SceneManager.GetSceneByName("VictoryScreen"));
                DontDestroyOnLoad(this);

                winner.transform.position = firstPodium.transform.position;*/
        // SceneManager.UnloadSceneAsync(currentScene);

        DontDestroyOnLoad(this);
        SceneManager.LoadScene("VictoryScreen");

    }

}
