using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 3.0f;

    //private float gravityValue = -9.81f;
    private float jumpGravity = -9.81f;
    private float fallGravity = -15.81f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    public float buttonTime = 0.75f;

    private float jumpHeight = 2f;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //jumped = context.ReadValue<bool>();
        jumped = context.action.triggered;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        float gravityValue = jumping ? jumpGravity : fallGravity;

        //grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            //jumpCancelled = false;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..
        if (jumped && groundedPlayer && !jumping)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
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

        /* if (jumpCancelled && jumping && playerVelocity.y > 0)
         {
             playerVelocity.y = -12.81f;
             jumping = false;
         }
         Debug.Log(jumping);
         Debug.Log(jumped);
         Debug.Log(playerVelocity.y);*/
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}


