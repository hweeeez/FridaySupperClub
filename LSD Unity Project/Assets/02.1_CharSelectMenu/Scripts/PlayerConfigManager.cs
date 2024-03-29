using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    GameObject sfxGO;
    AudioSource selectsfx;
    public GameObject map1;
    public GameObject map2;
    public GameObject mapCanvas;
    string p1tag;
    string p2tag;
    string p3tag;
    string p4tag;
    public GameObject[] tagged;
    private bool readyUp;
    private List<PlayerInput> players;
    private List<GameObject> playerobj;
    public List<SelectChar> playerList;
    public List<List<GameObject>> charaList;
    public GameObject LoadingPanel;
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
    private bool sceneloaded;
    private bool p1Ready;
    private bool p2Ready;
    private bool p3Ready;
    private bool p4Ready;

    public Camera mainCamera;
    private GameObject bgCanvas;
    [SerializeField]
    private int MaxPlayers = 4;
    public static PlayerConfigManager Instance { get; private set; }
    void Awake()
    {
        sfxGO = GameObject.Find("CharSelectSFX");
        selectsfx = sfxGO.GetComponent<AudioSource>();
        sceneloaded = false;
        bgCanvas = GameObject.Find("BackgroundCanvas");
        var bgCamera = bgCanvas.GetComponent<Canvas>();
        bgCamera.worldCamera = mainCamera;
        charaList = new List<List<GameObject>>();
        playerList = new List<SelectChar>();
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
        playerobj.Add(g1);
        playerobj.Add(g2);
        playerobj.Add(g3);
        playerobj.Add(g4);
        g2.transform.localScale = new Vector3(0, 0, 0);
        g3.transform.localScale = new Vector3(0, 0, 0);
        g4.transform.localScale = new Vector3(0, 0, 0);

        for (int a = 0; a < 4; a++)
        {
            playerList.Add(playerobj[a].GetComponent<SelectChar>());
        }

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
    IEnumerator playerActive(GameObject player, GameObject player2)
    {

        yield return new WaitForSeconds(1f);
        player2.transform.localScale = new Vector3(1, 1, 1);
        player.transform.localScale = new Vector3(0, 0, 0);
        foreach (GameObject tag in tagged)
        {
            tag.SetActive(false);
        }
    }
    private void Update()
    {

        if (!p1Ready && g1.GetComponent<SelectChar>().isReady && g1.GetComponent<SelectChar>().canSelect)
        {
            sprite1 = g1.GetComponent<SelectChar>().readySprite.name;
            PlayerPrefs.SetString("Sprite1", sprite1);

            p1tag = g1.GetComponent<SelectChar>().charTaken.gameObject.tag;

            int index = PlayerPrefs.GetInt("charTaken");
            foreach (GameObject obj in playerobj)
            {
                obj.GetComponent<SelectChar>().charList.RemoveAt(index);
            }
            tagged = GameObject.FindGameObjectsWithTag(g1.GetComponent<SelectChar>().charTaken.gameObject.tag);
            p1Ready = true;
            StartCoroutine(playerActive(g1, g2));
        }


        if (!p2Ready && g2.GetComponent<SelectChar>().isReady && g2.GetComponent<SelectChar>().canSelect)
        {
            p2tag = g2.GetComponent<SelectChar>().charTaken.gameObject.tag;

            int index = PlayerPrefs.GetInt("charTaken");
            foreach (GameObject obj in playerobj)
            {
                obj.GetComponent<SelectChar>().charList.RemoveAt(index);
            }
            tagged = GameObject.FindGameObjectsWithTag(g2.GetComponent<SelectChar>().charTaken.gameObject.tag);

            sprite2 = g2.GetComponent<SelectChar>().readySprite.name;
            p2Ready = true;
            print("p2ready");

            PlayerPrefs.SetString("Sprite2", sprite2);
            StartCoroutine(playerActive(g2, g3));
        }

        if (!p3Ready && p2Ready && g3.GetComponent<SelectChar>().isReady && g3.GetComponent<SelectChar>().canSelect)
        {
            p3tag = g3.GetComponent<SelectChar>().charTaken.gameObject.tag;
            int index = PlayerPrefs.GetInt("charTaken");
            foreach (GameObject obj in playerobj)
            {
                obj.GetComponent<SelectChar>().charList.RemoveAt(index);
            }
            tagged = GameObject.FindGameObjectsWithTag(g3.GetComponent<SelectChar>().charTaken.gameObject.tag);

            p3Ready = true;
            sprite3 = g3.GetComponent<SelectChar>().readySprite.name;
            print("p3ready");
            PlayerPrefs.SetString("Sprite3", sprite3);
            StartCoroutine(playerActive(g3, g4));
            print("P3: " + sprite3);
        }
        if (!p4Ready && g4.GetComponent<SelectChar>().canSelect && g4.GetComponent<SelectChar>().isReady)
        {
            StartCoroutine(fourReady());
            sprite4 = g4.GetComponent<SelectChar>().readySprite.name;
            PlayerPrefs.SetString("Sprite4", sprite4);

        }

        if (p1Ready && p2Ready && p3Ready && p4Ready && !sceneloaded)
        {
            mapCanvas.SetActive(true);
            //LoadingPanel.SetActive(true);
            g1.SetActive(false);
            g2.SetActive(false); g3.SetActive(false); g4.SetActive(false);
            sceneloaded = true;
        }

    }
    IEnumerator fourReady()
    {
        yield return new WaitForSeconds(1f);
        p4Ready = true;
    }
    public void mapOne()
    {
        selectsfx.Play();
        PlayerPrefs.SetString("MapSelect", "MapOne");
        StartCoroutine(mapSelect());
    }
    public void mapTwo()
    {
        selectsfx.Play();
        PlayerPrefs.SetString("MapSelect", "MapTwo");
        StartCoroutine(mapSelect());
    }
    IEnumerator mapSelect()
    {
        yield return new WaitForSeconds(1f);
        mapCanvas.SetActive(false);
        LoadingPanel.SetActive(true);
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