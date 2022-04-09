using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class characterspawn : MonoBehaviour
{
    public GameObject Map2;
    public GameObject Map1;
    private GameObject bg;
    private PlayerConfigManager configManager;
    private GameObject playerConfigMan;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;
    public Sprite konpeito;
    public Sprite rocksugar;
    public Sprite macaroon;
    public Sprite tanghulu;
    public GameObject kpGO;
    public GameObject rsGO;
    public GameObject macGO;
    public GameObject thGO;
    //  public GameObject Map1;
    //public GameObject Map2;
    public RuntimeAnimatorController kpAnim;
    public RuntimeAnimatorController rsAnim;
    public RuntimeAnimatorController thAnim;
    public RuntimeAnimatorController macAnim;

    void Awake()
    {
        bg = GameObject.Find("BackgroundCanvas");
        Destroy(bg);
        string Sprite1 = PlayerPrefs.GetString("Sprite1");
        string Sprite2 = PlayerPrefs.GetString("Sprite2");
        string Sprite3 = PlayerPrefs.GetString("Sprite3");
        string Sprite4 = PlayerPrefs.GetString("Sprite4");
        string mapChosen = PlayerPrefs.GetString("MapSelect");
        if (mapChosen == "MapOne")
        {
            Map1.SetActive(true);
            playerOne.transform.position = new Vector2(20.9f, 15.92f);
            playerTwo.transform.position = new Vector2(20.9f, 15.92f);
            playerThree.transform.position = new Vector2(-21.1f, 15.92f);
            playerFour.transform.position = new Vector2(-21.1f, 15.92f);
            playerOne.GetComponent<SpriteRenderer>().flipX = true;
            playerTwo.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (mapChosen == "MapTwo")
        {
            Map2.SetActive(true);
            playerOne.transform.position = new Vector2(-22.96f, 15.92f);
            playerTwo.transform.position = new Vector2(-14.23f, 15.92f);
            playerThree.transform.position = new Vector2(14.12f, 15.92f);
            playerFour.transform.position = new Vector2(22.97f, 15.92f);
            playerThree.GetComponent<SpriteRenderer>().flipX = true;
            playerFour.GetComponent<SpriteRenderer>().flipX = true;
        }
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
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);

    }

}

