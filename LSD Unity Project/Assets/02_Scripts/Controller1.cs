using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller1 : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;

    private float jumpGravity = -9.81f;
    private float fallGravity = -19.81f;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped;
    private bool isFalling;
    public float buttonTime = 0.75f;
    [SerializeField]
    public float jumpHeight = 4f;
    public float cancelRate = 100;
    float jumpTime;
    float fallMultiplier = 2.0f;
    bool jumping = false;
    bool jumpCancelled;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = new PlayerInput();


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        //grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            jumpCancelled = false;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        float gravity = jumping ? jumpGravity : fallGravity;
        /*     if (playerVelocity.y <= 0 && jumping)
             {
                 isFalling = true;
             }*/
        if (jumped && groundedPlayer && !jumping)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumping = true;
            jumpTime = 0;
        }
        if (jumping)
        {

            jumpTime += Time.deltaTime;
            if (!jumped)
            {
                jumpCancelled = true;
            }

            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }

        if (jumpCancelled && jumping && playerVelocity.y > 0)
        {
            jumping = false;
        }

        Debug.Log(jumped);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }



}




