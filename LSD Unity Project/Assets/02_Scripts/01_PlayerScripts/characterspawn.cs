using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class characterspawn : MonoBehaviour
{
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


    void Awake()
    {
        string Sprite1 = PlayerPrefs.GetString("Sprite1");
        string Sprite2 = PlayerPrefs.GetString("Sprite2");
        string Sprite3 = PlayerPrefs.GetString("Sprite3");
        string Sprite4 = PlayerPrefs.GetString("Sprite4");


        if (Sprite1 == "Konpeito")
        {
            playerOne.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite1 == "Macaroon")
        {
            playerOne.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite1 == "Tanghulu")
        {
            playerOne.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite1 == "Rocksugar")
        {
            playerOne.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        if (Sprite2 == "Konpeito")
        {
            playerTwo.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite2 == "Macaroon")
        {
            playerTwo.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite2 == "Tanghulu")
        {
            playerTwo.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite2 == "Rocksugar")
        {
            playerTwo.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        if (Sprite3 == "Konpeito")
        {
            playerThree.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite3 == "Macaroon")
        {
            playerThree.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite3 == "Tanghulu")
        {
            playerThree.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite3 == "Rocksugar")
        {
            playerThree.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        if (Sprite4 == "Konpeito")
        {
            playerFour.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite4 == "Macaroon")
        {
            playerFour.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite4 == "Tanghulu")
        {
            playerFour.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite4 == "Rocksugar")
        {
            playerFour.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        playerOne.transform.position = new Vector2(20.9f, 9.6f);
        playerTwo.transform.position = new Vector2(20.9f, -2.78f);
        playerThree.transform.position = new Vector2(-21.1f, 9.1f);
        playerFour.transform.position = new Vector2(-21.1f, -3.4f);
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);

    }
}

