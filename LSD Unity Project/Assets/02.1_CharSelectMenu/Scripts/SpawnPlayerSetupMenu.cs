using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject charlist;
    public GameObject playersetupmenuPrefab;
    public PlayerInput input;
    private void Awake()
    {
        var rootMenu = GameObject.Find("MainLayout");
        if(rootMenu != null)
        {
            var menu = Instantiate(playersetupmenuPrefab, rootMenu.transform);
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
           // menu.GetComponent<SelectChar>().setPlayerindex(input.playerIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
