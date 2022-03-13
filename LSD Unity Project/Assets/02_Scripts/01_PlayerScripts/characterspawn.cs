using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class characterspawn : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;
    void Awake()
    {
   
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        player1.transform.position = new Vector2(20.9f, 9.6f);
        player2.transform.position = new Vector2(20.9f, -2.78f);
        player3.transform.position = new Vector2(-21.1f, 9.1f);
        player4.transform.position = new Vector2(-21.1f, -3.4f);
    }
}

