using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class characterspawn : MonoBehaviour
{
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
    public GameObject Map1;
    public GameObject Map2;
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
        if(mapChosen == "MapOne")
        {
            Map1.SetActive(true);
        }
            if (mapChosen == "MapTwo")
        {
            Map2.SetActive(true);
        }
                if (Sprite1 == "KonpeitoSprite")
        {
            playerOne = Resources.Load("KonpeiGO") as GameObject;
            //    Animator animator = playerOne.GetComponent<Animator>();
            //  animator.runtimeAnimatorController = kpAnim;
            //playerOne.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite1 == "MacaroonSprite")
        {
            playerOne = Resources.Load("MacGO") as GameObject;
            //Animator animator = playerOne.GetComponent<Animator>();
            //  animator.runtimeAnimatorController = macAnim;
            //playerOne.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite1 == "TangHuluSprite")
        {
            playerOne = Resources.Load("TangHuluGO") as GameObject;
            //  Animator animator = playerOne.GetComponent<Animator>();
            // animator.runtimeAnimatorController = thAnim;
            //playerOne.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite1 == "RockSugarSprite")
        {
            playerOne = Resources.Load("RockSugarGO") as GameObject;
            //  Animator animator = playerOne.GetComponent<Animator>();
            //  animator.runtimeAnimatorController = rsAnim;
            //playerOne.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        if (Sprite2 == "KonpeitoSprite")
        {
            playerTwo = Resources.Load("KonpeiGO") as GameObject;
            //   Animator animator = playerTwo.GetComponent<Animator>();
            // animator.runtimeAnimatorController = kpAnim;
            //playerTwo.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite2 == "MacaroonSprite")
        {
            playerTwo = Resources.Load("MacGO") as GameObject;
            // Animator animator = playerTwo.GetComponent<Animator>();
            //   animator.runtimeAnimatorController = macAnim;
            //playerTwo.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite2 == "TangHuluSprite")
        {
            playerTwo = Resources.Load("TangHuluGO") as GameObject;
            //     Animator animator = playerTwo.GetComponent<Animator>();
            //animator.runtimeAnimatorController = thAnim;
            //playerTwo.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite2 == "RockSugarSprite")
        {
            playerTwo = Resources.Load("RockSugarGO") as GameObject;
            //Animator animator = playerTwo.GetComponent<Animator>();
            //animator.runtimeAnimatorController = rsAnim;
            //playerTwo.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        if (Sprite3 == "KonpeitoSprite")
        {
            playerThree = Resources.Load("KonpeiGO") as GameObject;
            // Animator animator = playerThree.GetComponent<Animator>();
            //animator.runtimeAnimatorController = kpAnim;
            //playerThree.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite3 == "MacaroonSprite")
        {
            playerThree = Resources.Load("MacGO") as GameObject;
            //Animator animator = playerThree.GetComponent<Animator>();
            //animator.runtimeAnimatorController = macAnim;
            //playerThree.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite3 == "TangHuluSprite")
        {
            playerThree = Resources.Load("TangHuluGO") as GameObject;
            // Animator animator = playerThree.GetComponent<Animator>();
            //animator.runtimeAnimatorController = thAnim;
            //playerThree.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite3 == "RockSugarSprite")
        {
            playerThree = Resources.Load("RockSugarGO") as GameObject;
            //           Animator animator = playerThree.GetComponent<Animator>();
            //         animator.runtimeAnimatorController = rsAnim;
            //playerThree.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        if (Sprite4 == "KonpeitoSprite")
        {
            playerFour = Resources.Load("KonpeiGO") as GameObject;
            //       Animator animator = playerFour.GetComponent<Animator>();
            //     animator.runtimeAnimatorController = kpAnim;
            //playerFour.GetComponent<SpriteRenderer>().sprite = konpeito;
        }
        if (Sprite4 == "MacaroonSprite")
        {
            playerFour = Resources.Load("MacGO") as GameObject;
            //   Animator animator = playerFour.GetComponent<Animator>();
            // animator.runtimeAnimatorController = macAnim;
            //playerFour.GetComponent<SpriteRenderer>().sprite = macaroon;
        }
        if (Sprite4 == "TangHuluSprite")
        {
            playerFour = Resources.Load("TangHuluGO") as GameObject;
            //Animator animator = playerFour.GetComponent<Animator>();
            //animator.runtimeAnimatorController = thAnim;
            //playerFour.GetComponent<SpriteRenderer>().sprite = tanghulu;
        }
        if (Sprite4 == "RockSugarSprite")
        {
            playerFour = Resources.Load("RockSugarGO") as GameObject;
            //    Animator animator = playerFour.GetComponent<Animator>();
            //  animator.runtimeAnimatorController = rsAnim;
            //playerFour.GetComponent<SpriteRenderer>().sprite = rocksugar;
        }
        playerOne.transform.position = new Vector2(20.9f, 9.6f);
        playerTwo.transform.position = new Vector2(20.9f, -2.78f);
        playerThree.transform.position = new Vector2(-21.1f, 9.1f);
        playerFour.transform.position = new Vector2(-21.1f, -3.4f);
        // StartCoroutine(instantiatePlayers());
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
    }
    IEnumerator instantiatePlayers()
    {
        yield return new WaitForSeconds(2f);
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
    }
}

