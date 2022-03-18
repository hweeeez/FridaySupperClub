using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
[RequireComponent(typeof(CharacterController))]
public class SelectChar : MonoBehaviour
{
    private int index;
    private GameObject[] characterList;
    private Vector2 playerInput;
    // Start is called before the first frame update
    public void OnSelecting(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();
    }
    private void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        if(playerInput.x == -1)
        {
            characterList[index].SetActive(false);

            print("left");
            index--;
            if (index < 0)
      index = characterList.Length - 1;
            characterList[index].SetActive(true);

        }
        if (playerInput.x == 1)
        {
            print("right");
        }
    }
}
