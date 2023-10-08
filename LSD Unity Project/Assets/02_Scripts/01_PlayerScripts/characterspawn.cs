using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
[RequireComponent(typeof(PlayerInput))]
public class characterspawn : MonoBehaviour
{
    PlayerInput player1;
    PlayerInput player2;
    PlayerInput player3;
    PlayerInput player4;
    public GameObject timerUI;
    public GameObject Map2;
    public GameObject Map1;
    private GameObject bg;
    private PlayerConfigManager configManager;
    private GameObject playerConfigMan;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;

    //  public GameObject Map1;
    //public GameObject Map2;

    string mapChosen;
    void Awake()
    {
        bg = GameObject.Find("BackgroundCanvas");
        Destroy(bg);
        string Sprite1 = PlayerPrefs.GetString("Sprite1");
        string Sprite2 = PlayerPrefs.GetString("Sprite2");
        string Sprite3 = PlayerPrefs.GetString("Sprite3");
        string Sprite4 = PlayerPrefs.GetString("Sprite4");
        mapChosen = PlayerPrefs.GetString("MapSelect");

        #region
        if (Sprite1 == "KonpeitoSprite")
        {
            playerOne = Resources.Load("KonpeiGO") as GameObject;

        }
        if (Sprite1 == "MacaroonSprite")
        {
            playerOne = Resources.Load("MacGO") as GameObject;

        }
        if (Sprite1 == "TangHuluSprite")
        {
            playerOne = Resources.Load("TangHuluGO") as GameObject;

        }
        if (Sprite1 == "RockSugarSprite")
        {
            playerOne = Resources.Load("RockSugarGO") as GameObject;

        }
        if (Sprite2 == "KonpeitoSprite")
        {
            playerTwo = Resources.Load("KonpeiGO") as GameObject;

        }
        if (Sprite2 == "MacaroonSprite")
        {
            playerTwo = Resources.Load("MacGO") as GameObject;

        }
        if (Sprite2 == "TangHuluSprite")
        {
            playerTwo = Resources.Load("TangHuluGO") as GameObject;

        }
        if (Sprite2 == "RockSugarSprite")
        {
            playerTwo = Resources.Load("RockSugarGO") as GameObject;

        }
        if (Sprite3 == "KonpeitoSprite")
        {
            playerThree = Resources.Load("KonpeiGO") as GameObject;

        }
        if (Sprite3 == "MacaroonSprite")
        {
            playerThree = Resources.Load("MacGO") as GameObject;

        }
        if (Sprite3 == "TangHuluSprite")
        {
            playerThree = Resources.Load("TangHuluGO") as GameObject;

        }
        if (Sprite3 == "RockSugarSprite")
        {
            playerThree = Resources.Load("RockSugarGO") as GameObject;

        }
        if (Sprite4 == "KonpeitoSprite")
        {
            playerFour = Resources.Load("KonpeiGO") as GameObject;

        }
        if (Sprite4 == "MacaroonSprite")
        {
            playerFour = Resources.Load("MacGO") as GameObject;

        }
        if (Sprite4 == "TangHuluSprite")
        {
            playerFour = Resources.Load("TangHuluGO") as GameObject;

        }
        if (Sprite4 == "RockSugarSprite")
        {
            playerFour = Resources.Load("RockSugarGO") as GameObject;

        }
        #endregion


        // StartCoroutine(instantiatePlayers());
        player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        if (mapChosen == "MapOne")
        {
            timerUI.GetComponent<TextMeshProUGUI>().color = new Color32(255, 212, 133, 255);
            Map1.SetActive(true);
            player1.gameObject.transform.position = new Vector2(20.9f, 9.6f);
            player2.gameObject.transform.position = new Vector2(20.9f, -2.78f);
            player3.gameObject.transform.position = new Vector2(-21.1f, 9.1f);
            player4.gameObject.transform.position = new Vector2(-21.1f, -3.4f);
            player1.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            player2.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            player1.gameObject.GetComponent<Controller>().spawnPos = new Vector3(20.79f, 16.1f, 0f);
            player2.gameObject.GetComponent<Controller>().spawnPos = new Vector3(5.3f, 16.1f, 0f);
            player3.gameObject.GetComponent<Controller>().spawnPos = new Vector3(-21.1f, 16.1f, 0f);
            player4.gameObject.GetComponent<Controller>().spawnPos = new Vector3(-6.33f, 16.1f, 0f);

        }
        if (mapChosen == "MapTwo")
        {
            timerUI.GetComponent<TextMeshProUGUI>().color = new Color32(255, 63, 28, 255);
            Map2.SetActive(true);
            player1.gameObject.transform.position = new Vector2(-22.96f, 15.92f);
            player2.gameObject.transform.position = new Vector2(-14.23f, 15.92f);
            player3.gameObject.transform.position = new Vector2(14.12f, 15.92f);
            player4.gameObject.transform.position = new Vector2(22.97f, 15.92f);
            player3.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            player4.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            player1.gameObject.GetComponent<Controller>().spawnPos = new Vector3(-22.96f, 15.92f, 0f);
            player2.gameObject.GetComponent<Controller>().spawnPos = new Vector3(-14.23f, 15.92f, 0f);
            player3.gameObject.GetComponent<Controller>().spawnPos = new Vector3(14.12f, 15.92f, 0f);
            player4.gameObject.GetComponent<Controller>().spawnPos = new Vector3(22.97f, 15.92f, 0f);
        }
        print("p1: " + player1.gameObject.name);
        print("p2: " + player2.gameObject.name);
        print("p3: " + player3.gameObject.name);
        print("p4: " + player4.gameObject.name);
    }
    private void Update()
    {
        if (mapChosen == "MapOne")
        {
            if (player1.GetComponent<Controller>().isAttacked == true)
            {
                player1.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (player2.GetComponent<Controller>().isAttacked == true)
            {
                player2.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (mapChosen == "MapTwo")
        {
            if (player3.GetComponent<Controller>().isAttacked == true)
            {
                player3.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (player4.GetComponent<Controller>().isAttacked == true)
            {
                player4.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

}

