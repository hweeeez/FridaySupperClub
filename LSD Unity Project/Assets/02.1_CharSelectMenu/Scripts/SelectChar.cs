using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterController))]
public class SelectChar : MonoBehaviour
{
    private int playerIndex;
    [SerializeField]
    private TextMeshProUGUI titleText;
    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;
    private PlayerConfigManager configManager;
    private float value;
    private int index;
    public GameObject[] characterList;
    private float playerInput;
    public Sprite readySprite;

    private void Start()
    {
        //index = PlayerPrefs.GetInt("CharacterSelected");
        configManager = GameObject.Find("PlayerConfigManager").GetComponent<PlayerConfigManager>();
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;

        }
        foreach (GameObject go in characterList)
            go.SetActive(false);
        if (characterList[0])
            characterList[0].SetActive(true);
    }
    public void setPlayerindex(int pi)
    {
        playerIndex = pi;
        titleText.SetText("Player" + (pi + 1).ToString());
        //ignoreInputTime = Time.time + ignoreInputTime;

    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterList[index].SetActive(false);

            index--;
            if (index < 0)
                index = characterList.Length - 1;

            characterList[index].SetActive(true);
        }
    }
    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterList[index].SetActive(false);

            index++;
            if (index == characterList.Length)
                index = 0;

            characterList[index].SetActive(true);
        }
    }

    public void OnSelect()
    {
        
        readySprite = characterList[index].GetComponent<Sprite>();
        if (!inputEnabled) { return; }

        //PlayerConfigManager.Instance.SetPlayerChar(playerIndex, readySprite);
        PlayerConfigManager.Instance.ReadyPlayer(playerIndex);
    }
    // Update is called once per frame
    void Update()
    {
     
    }

}
