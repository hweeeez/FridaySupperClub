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
    private bool inputEnabled;
    public GameObject configManagerObj;
    private PlayerConfigManager configManager;
    private float value;
    private int index;
    public GameObject[] characterList;
    private float playerInput;
    public Sprite readySprite;
    public bool isReady = false;
    private void Start()
    {
        //index = PlayerPrefs.GetInt("CharacterSelected");
        configManager = configManagerObj.GetComponent<PlayerConfigManager>();
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


    public void OnLeft(InputAction.CallbackContext context)
    {
        print("left!");
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

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           isReady = true;
            readySprite = characterList[index].GetComponent<SpriteRenderer>().sprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale == Vector3.zero)
        {
            characterList[0].SetActive(true);
        }
    }

}
