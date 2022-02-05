using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    
    private float gravityValue = -9.81f;
    
    private Vector2 movementInput = Vector2.zero;
    private bool jumped;
    public float buttonTime = 1f;
    public float jumpHeight = 1f;
    public float cancelRate = 100;
    float jumpTime = 0.5f;
    bool jumping; 
    bool jumpCancelled;
    bool canJump = true;
    float initialjumpVelocity;
    float fallMultiplier = 2.0f;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        //float timeToApex = jumpTime / 2;
        //gravityValue = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        //initialjumpVelocity = (2 * jumpHeight) / timeToApex;
        //bool isFalling = playerVelocity.y <= 0.0f;
        
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


        // Changes the height position of the player..
        //canjump
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            //playerVelocity.y = initialjumpVelocity;
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (jumping)
        {

            jumpTime += Time.deltaTime;
            if (jumped)
            {
                jumpCancelled = true;
            }

            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (jumpCancelled && jumping && playerVelocity.y > 0)
        {
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * gravityValue * fallMultiplier);
        
        }

    }
}


