using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour { 
    private bool readyUp;
    private List<PlayerInput> players;
    private List<GameObject> playerobj;
    static PlayerInput player1;
    static PlayerInput player2;
    static PlayerInput player3;
    static PlayerInput player4;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    private SelectChar selectChar;
    public InputActionAsset selectMenu;

    private PlayerInputManager PlayerInputManager;
    [SerializeField]
    private int MaxPlayers = 4;
    public static PlayerConfigManager Instance { get; private set; }
    void Awake()
    {

        players = new List<PlayerInput>();
        playerobj = new List<GameObject>();
        PlayerInputManager = this.GetComponent<PlayerInputManager>();
  
        player1 = PlayerInput.Instantiate(prefab: p1, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
        player2 = PlayerInput.Instantiate(prefab: p2, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
        player3 = PlayerInput.Instantiate(prefab: p3, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current);
        player4 = PlayerInput.Instantiate(prefab: p4, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current);
        g1 = GameObject.Find("Player1(Clone)");
        g2 = GameObject.Find("Player2(Clone)");
        g3 = GameObject.Find("Player3(Clone)");
        g4 = GameObject.Find("Player4(Clone)");
    
/*        g2.GetComponent<SelectChar>().enabled = false;
        g2.transform.localScale = new Vector3(0, 0, 0);
        g3.GetComponent<SelectChar>().enabled = false;
        g3.transform.localScale = new Vector3(0, 0, 0);
        g4.GetComponent<SelectChar>().enabled = false;
        g4.transform.localScale = new Vector3(0, 0, 0);*/
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
            print("p1ready");
            g1.GetComponent<SelectChar>().enabled = false;
            g1.transform.localScale = new Vector3(0, 0, 0);
            g2.GetComponent<SelectChar>().enabled = true;
            g2.transform.localScale = new Vector3(1, 1, 1);
        }

        if (p2.GetComponent<SelectChar>().isReady)
        {
            print("p2ready");
            p2.GetComponent<SelectChar>().enabled = false;
            p2.transform.localScale = new Vector3(0, 0, 0);
            p3.GetComponent<SelectChar>().enabled = true;
            p3.transform.localScale = new Vector3(1, 1, 1);
        }

        if (p3.GetComponent<SelectChar>().isReady)
        {
            print("p3ready");
            p3.GetComponent<SelectChar>().enabled = false;
            p3.transform.localScale = new Vector3(0, 0, 0);
            p4.GetComponent<SelectChar>().enabled = true;
            p4.transform.localScale = new Vector3(1, 1, 1);
        }

    }
   


    public void SetPlayerChar(int index, Sprite pickchar)
    {
        pickchar = selectChar.readySprite;
         //  playerConfigs[index].PlayerChar = pickchar;
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