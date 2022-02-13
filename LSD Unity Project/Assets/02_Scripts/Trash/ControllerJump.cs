using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(CharacterController))]
public class ControllerJump : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private Vector2 appliedMovement;
    private float gravityValue = -9.8f;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped;
    private float jumpHeight = 5f;
    float jumpTime = 0.75f;
    bool jumping;
    float initialjumpVelocity;
    float fallMultiplier = 2.0f;
    float groundedGravity = 0;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        float timeToApex = jumpTime / 2;
        gravityValue = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        initialjumpVelocity = (2 * jumpHeight) / timeToApex;

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }
    void handleJump()
    {
        if (!jumping && controller.isGrounded && jumped)
        {
            jumping = true;

            movementInput.y = initialjumpVelocity;
            appliedMovement.y = initialjumpVelocity;
        }
        else if (jumped && jumping && controller.isGrounded)
        {
            jumping = false;
        }
    }

    /*    void handleJump()
        {
            if (!jumping && groundedPlayer && jumped)
            {
                jumping = true;
                playerVelocity.y = initialjumpVelocity * .5f;
            }
            else if (!jumped && jumping && groundedPlayer)
            {
                jumping = false;
            }
        }*/
    void handleGravity()
    {
        bool isFalling = movementInput.y <= 0.0f || !jumped;
        float fallMultiplier = 2.0f;
        // apply proper gravity if the player is grounded or not
        if (controller.isGrounded)
        {
            if (jumping)
            {
                movementInput.y = groundedGravity;
            }
            else if (isFalling)
            {
                float previousYVelocity = movementInput.y;
                movementInput.y = movementInput.y + (gravityValue * fallMultiplier * Time.deltaTime);
                appliedMovement.y = Mathf.Max(previousYVelocity + movementInput.y * .5f, -20.0f);
                // applied when character is not grounded
            }
            else
            {
                float previousYVelocity = movementInput.y;
                movementInput.y = movementInput.y + (gravityValue * Time.deltaTime);
                appliedMovement.y = (previousYVelocity + movementInput.y) * .5f;
            }
        }
    }



    /* void handleGravity()
     {
         bool isFalling = playerVelocity.y <= 0.0f || !jumped;
         float fallMultiplier = 2.0f;


         if (isFalling)
         {
             float previousYVelocity = playerVelocity.y;
             float newYVelocity = playerVelocity.y + (gravityValue * fallMultiplier * Time.deltaTime);
             float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
             playerVelocity.y = nextYVelocity;
         }
         else
         {
             float previousYVelocity = playerVelocity.y;
             float newYVelocity = playerVelocity.y + (gravityValue * Time.deltaTime);
             float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
             playerVelocity.y = nextYVelocity;
         }
     }*/



    void Update()
    {
        groundedPlayer = controller.isGrounded;

        //grounded
        /*   if (groundedPlayer && playerVelocity.y < 0)
           {
               playerVelocity.y = 0f;
           }
           else
           {
               playerVelocity.y += gravityValue * Time.deltaTime;
           }*/
        /*
                Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
                controller.Move(move * Time.deltaTime * playerSpeed);
        */

        // Changes the height position of the player..
        //canjump
        /*        if (jumped && groundedPlayer)
                {
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
                    //playerVelocity.y = initialjumpVelocity;
                    jumping = true;
                    jumpCancelled = false;
                    jumpTime = 0;
                }*/

        // playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);


        appliedMovement.x = movementInput.x;
        appliedMovement.y = movementInput.y;
        controller.Move(appliedMovement * Time.deltaTime * playerSpeed);
        handleGravity();
        handleJump();
    }



}


