using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    private bool readyUp;
    private List<PlayerInput> players;
    private List<GameObject> playerobj;
    public string sprite1;
    public string sprite2;
    public string sprite3;
    public string sprite4;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;

    private bool p1Ready;
    private bool p2Ready;
    private bool p3Ready;
    private bool p4Ready;


    [SerializeField]
    private int MaxPlayers = 4;
    public static PlayerConfigManager Instance { get; private set; }
    void Awake()
    {

        players = new List<PlayerInput>();
        playerobj = new List<GameObject>();

        var player1 = PlayerInput.Instantiate(prefab: p1, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(prefab: p2, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
        var player3 = PlayerInput.Instantiate(prefab: p3, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current);
        var player4 = PlayerInput.Instantiate(prefab: p4, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current);
        g1 = GameObject.Find("Player1(Clone)");
        g2 = GameObject.Find("Player2(Clone)");
        g3 = GameObject.Find("Player3(Clone)");
        g4 = GameObject.Find("Player4(Clone)");

        g2.transform.localScale = new Vector3(0, 0, 0);
        g3.transform.localScale = new Vector3(0, 0, 0);
        g4.transform.localScale = new Vector3(0, 0, 0);
        if (Instance != null)
        {
            Debug.Log("create instance of singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
    private void Update()
    {

        if (g1.GetComponent<SelectChar>().isReady)
        {
            sprite1 = g1.GetComponent<SelectChar>().readySprite.name;
            PlayerPrefs.SetString("Sprite1", sprite1);
            p1Ready = true;
            print("p1ready");
            //g1.GetComponent<SelectChar>().enabled = false;
            g1.transform.localScale = new Vector3(0, 0, 0);
            //g2.GetComponent<SelectChar>().enabled = true;
            g2.transform.localScale = new Vector3(1, 1, 1);
        }

        if (g2.GetComponent<SelectChar>().isReady)
        {
            sprite2 = g2.GetComponent<SelectChar>().readySprite.name;
            p2Ready = true;
            print("p2ready");
            g2.transform.localScale = new Vector3(0, 0, 0);
            g3.transform.localScale = new Vector3(1, 1, 1);
            PlayerPrefs.SetString("Sprite2", sprite2);

        }

        if (g3.GetComponent<SelectChar>().isReady)
        {
            p3Ready = true;
            sprite3 = g3.GetComponent<SelectChar>().readySprite.name;
            print("p3ready");
            g3.transform.localScale = new Vector3(0, 0, 0);
            g4.transform.localScale = new Vector3(1, 1, 1);
            PlayerPrefs.SetString("Sprite3", sprite3);

        }
        if (g3.GetComponent<SelectChar>().isReady)
        {
            p4Ready = true;
            sprite4 = g4.GetComponent<SelectChar>().readySprite.name;
            PlayerPrefs.SetString("Sprite4", sprite4);

        }
        bool sceneloaded = false;
        if (p1Ready && p2Ready && p3Ready && p4Ready && !sceneloaded)
        {
            SceneManager.LoadScene("PlayableTest01");
            sceneloaded = true;
        }
    }





    /*    public void ReadyPlayer(int index)
        {

            playerConfigs[index].IsReady = true;
            if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
            {
                SceneManager.LoadScene("PlayableTest01");
            }
        }*//*    public void ReadyPlayer(int index)
        {

            playerConfigs[index].IsReady = true;
            if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
            {
                SceneManager.LoadScene("PlayableTest01");
            }
        }*/





}