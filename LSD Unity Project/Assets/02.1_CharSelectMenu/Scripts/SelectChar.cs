using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
[RequireComponent(typeof(CharacterController))]
public class SelectChar : MonoBehaviour
{
    private float value;
    private int index;
    private GameObject[] characterList;
    private float playerInput;
    // Start is called before the first frame update
    /* public void OnSelecting(InputAction.CallbackContext context)
     {
         playerInput = context.ReadValue<float>();
     }*/
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

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
    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        //SceneManager.LoadScene("DesertScene");
    }
    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterList[index].SetActive(false);

            print("left");
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
    // Update is called once per frame
    void Update()
    {

    }

}
