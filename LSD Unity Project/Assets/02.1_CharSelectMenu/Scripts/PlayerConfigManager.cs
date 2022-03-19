using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{public GameObject playerPrefab;
    public bool isReady = false;
    static PlayerInput player1;
    static PlayerInput player2;
    static PlayerInput player3;
    static PlayerInput player4;
    private SelectChar selectChar;
    private List<PlayerConfig> playerConfigs;
    private PlayerInputManager playerInputManager;
    [SerializeField]
    private int MaxPlayers = 4;
    public static PlayerConfigManager Instance { get; private set; }
    void Awake()
    {

        playerInputManager = this.GetComponent<PlayerInputManager>();
        /*  for (int i = 0; i < 4; i++)
          {
              var player = playerInputManager.JoinPlayer(playerIndex: i, 0, controlScheme: "Keyboard" + (i + 1), pairWithDevice: Keyboard.current);
              player = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: i, controlScheme: "Keyboard" + (i + 1), pairWithDevice: Keyboard.current, splitScreenIndex: -1);      
              player.gameObject.name = "Player" + (i + 1);
          }*/

        var player1 = playerInputManager.JoinPlayer(playerIndex: 0, 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
        player1 = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
        if (Instance != null)
        {
            Debug.Log("create instance of singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfig>();

        }
    }
    private void Update()
    {
        print(isReady);
    }

    public void JoinPlayer ()
    {
       
        if (playerConfigs[2].IsReady)
        {
                    print("Player4 Joined");
                    player4 = playerInputManager.JoinPlayer(playerIndex: 3, 0, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current);
                    player4 = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        }
      
        if (playerConfigs[1].IsReady)
        {
         print("Player3 Joined");
         player3 = playerInputManager.JoinPlayer(playerIndex: 2, 0, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current);
         player3 = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: 2, controlScheme: "Keyboard3" , pairWithDevice: Keyboard.current, splitScreenIndex: -1);
         }
       
                if (playerConfigs[0].IsReady)
                {
                    print("Player1 Joined");
                    player2 = playerInputManager.JoinPlayer(playerIndex: 1, 0, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
                    player2 = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: 1, controlScheme: "Keyboard2" , pairWithDevice: Keyboard.current, splitScreenIndex: -1);
                    player1.DeactivateInput();
                }
           
    } 
    public void SetPlayerChar(int index, Sprite pickchar)
    {
        pickchar = selectChar.readySprite;
           playerConfigs[index].PlayerChar = pickchar;
    }
    
    public void ReadyPlayer(int index)
    {
       
        print("select");
        JoinPlayer();
        playerConfigs[index].IsReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("PlayableTest01");
        }
    }

   public void HandlePlayerJoin (PlayerInput pi)
    {
        Debug.Log("Player joined!" + pi.playerIndex);
        pi.transform.SetParent(transform);
        //checking whether we have added player
        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfig(pi));

        }
    }
}



public class PlayerConfig
{
    public PlayerConfig(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    public Sprite PlayerChar { get; set; }

}