using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


[RequireComponent(typeof(CharacterController))]
public class SelectChar : MonoBehaviour
{
    private int index;
    public List<GameObject> charList;
    public GameObject[] characterList;
    private GameObject charTaken;
    public Sprite readySprite;
    public bool isReady = false;
    private void Start()
    {
        //index = PlayerPrefs.GetInt("CharacterSelected");
        charList = new List<GameObject>(transform.childCount);
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
            charList.Add(transform.GetChild(i).gameObject);
        }
        foreach (GameObject go in charList)
            go.SetActive(false);
        if (charList[0])
            charList[0].SetActive(true);
    }


    public void OnLeft(InputAction.CallbackContext context)
    {
        print("left!");
        if (context.performed)
        {
            charList[index].SetActive(false);

            index--;
            if (index < 0)
                //index = charList.Remove(index);

            charList[index].SetActive(true);
        }
    }
    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            charList[index].SetActive(false);

            index++;
            if (index == charList.Count)
                index = 0;

            charList[index].SetActive(true);
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isReady = true;
            charTaken = charList[index];
            readySprite = charList[index].GetComponent<SpriteRenderer>().sprite;
            print(readySprite.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale == Vector3.zero)
        {
            charList[0].SetActive(true);
        }
        charList.Remove(charTaken);
    }

}
