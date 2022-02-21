using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class characterspawn : MonoBehaviour
{
    public GameObject playerPrefab;
    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            var player = PlayerInput.Instantiate(prefab: playerPrefab, playerIndex: i, controlScheme: "Keyboard" + (i + 1), pairWithDevice: Keyboard.current, splitScreenIndex: -1);
            player.transform.position = new Vector2(-4 + 2 * i, 4);
            player.gameObject.name = "Player" + (i + 1);
        }
    }
}
