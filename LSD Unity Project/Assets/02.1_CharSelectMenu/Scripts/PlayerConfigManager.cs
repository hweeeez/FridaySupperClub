using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfig> playerConfigs;

    [SerializeField]
    private int MaxPlayers = 4;
    public static PlayerConfigManager Instance { get; private set; }
    void Awake()
    {
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
        public void SetPlayerChar(int index, Texture2D pickchar)
    {
        playerConfigs[index].PlayerChar = pickchar;
    }
    
    public void ReadyPlayer(int index)
    {
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
    public Texture2D PlayerChar { get; set; }

}