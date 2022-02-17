using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed = 3.0f;


    //private float gravityValue = -9.81f;
    [SerializeField]
    private float jumpGravity = -11.81f;
    [SerializeField]
    private float fallGravity = -15.81f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumpButtonHeld;
    public float buttonTime = 0.75f;

    private float maxHeight = 4f;
    private float minHeight = 2f;
    //private float jumpHeight = 2f;
    public float cancelRate = 100;
    float jumpTime;
    bool startedJump;
    float startY;

    private bool isGrounded;
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
        if (context.action.triggered)
        {
            print("jump!");
            jumpButtonHeld = true;
        }
        else if (context.action.phase == InputActionPhase.Canceled)
        {
            print("cancelled");
            jumpButtonHeld = false;
            startedJump = false;
        }
    }

    void Update()
    {

        float gravityValue = jumpGravity;// startedJump &&  ? jumpGravity : fallGravity;
        float jumpHeight = minHeight;// jumpCancelled ? minHeight : maxHeight;

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
            startedJump = false;
        }
        print("isGrounded: " + controller.isGrounded);

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        bool tryAccelerate = false;
        float jumpedDistance = transform.position.y - startY;
        //print(startedJump + "startedJump");
        //print(jumpedDistance + "jumpeddistance");

        if (jumpButtonHeld)
        {
            if (controller.isGrounded)
            {
                print("statjump");
                startedJump = true;
                startY = transform.position.y;
            }
            tryAccelerate = true;
        }
        else if (startedJump && jumpedDistance < minHeight)
        {
            tryAccelerate = true;
        }
        if (tryAccelerate)
        {
            bool maxHeightExceeded = jumpedDistance > maxHeight;
            if (startedJump && !maxHeightExceeded)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue) * Time.deltaTime * 10;
            }
            else if (startedJump && maxHeightExceeded)
            {
                print("drop");
                startedJump = false;
            }
        }




        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


}


