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
        /*for (int i = 0; i < 4; i++)
        {
            var player = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: i, controlScheme: "Keyboard" + (i + 1), pairWithDevice: Keyboard.current, splitScreenIndex: -1);
            player.transform.position = new Vector2(-4 + 2 * i, 4);
            player.gameObject.name = "Player" + (i + 1);
        }*/
        var player1 = PlayerInput.Instantiate(prefab: playerOne, playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player2 = PlayerInput.Instantiate(prefab: playerTwo, playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player3 = PlayerInput.Instantiate(prefab: playerThree, playerIndex: 2, controlScheme: "Keyboard3", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        var player4 = PlayerInput.Instantiate(prefab: playerFour, playerIndex: 3, controlScheme: "Keyboard4", pairWithDevice: Keyboard.current, splitScreenIndex: -1);
        player1.transform.position = new Vector2(-4, 4);
        player2.transform.position = new Vector2(-2, 4);
        player3.transform.position = new Vector2(0, 4);
        player4.transform.position = new Vector2(2, 4);
    }
}

