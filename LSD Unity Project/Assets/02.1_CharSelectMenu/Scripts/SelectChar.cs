using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


[RequireComponent(typeof(CharacterController))]
public class SelectChar : MonoBehaviour
{
    public GameObject rightKey;
    public GameObject leftKey;
    private int index;
    public List<GameObject> charList;
    public GameObject[] characterList;
    public GameObject charTaken;
    public Sprite readySprite;
    public bool isReady = false;
    private void Start()
    {

        foreach (GameObject go in charList)
            go.SetActive(false);
        if (charList[0])
            charList[0].SetActive(true);
    }


    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            charList[index].SetActive(false);

            index--;
            if (index < 0)
                index = charList.Count - 1;

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
            Animator animator = charTaken.GetComponent<Animator>();
            animator.SetBool("Confirm", true);
            PlayerPrefs.SetInt("charTaken", charList.IndexOf(charTaken));
            readySprite = charList[index].GetComponent<SpriteRenderer>().sprite;
            print(readySprite.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale == Vector3.zero)
        {
            print(charList[0]);
            charList[0].SetActive(true);
            leftKey.SetActive(false);
            rightKey.SetActive(false);
        }
        else
        {
            leftKey.SetActive(true);
            rightKey.SetActive(true);
        }
        // charList.Remove(charTaken);
    }

}
