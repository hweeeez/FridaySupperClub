using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private InputActionReference actionReference;

    [SerializeField]
    private float defplayerSpeed = 3.0f;
    [SerializeField]
    private float dashSpeed = 8.0f;
    //private float gravityValue = -9.81f;
    [SerializeField]
    private float jumpGravity = -10.81f;
    [SerializeField]
    private float fallGravity = -15.81f;
    private float slamGravity = -80f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumpButtonHeld;
    public float buttonTime = 0.75f;

    private float maxHeight = 3f;
    private float minHeight = 1.5f;

    bool startedJump;
    float startY;
    private bool slammed = false;

    private bool dash = false;
    private bool canDash;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    private void Start()
    {


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!actionReference.action.interactions.Contains("Press") && actionReference.action.interactions.Contains("MultiTap"))
        {
            return;
        }
        actionReference.action.started += context =>
        {
            if (context.interaction is PressInteraction)
            {
                canDash = false;
            }
            else if (context.interaction is MultiTapInteraction)
            {
                canDash = true;
            }
        };
        actionReference.action.performed += context =>
        {
            if (context.interaction is PressInteraction)
            {
                movementInput = context.ReadValue<Vector2>();
            }
            else if (context.interaction is MultiTapInteraction)
            {
                movementInput = context.ReadValue<Vector2>();

            }
        };
        actionReference.action.canceled += context =>
        {
            if (context.interaction is PressInteraction)
            {
                canDash = true;
            }
            else if (context.interaction is MultiTapInteraction)
            {
                canDash = false;
            }
        };
    }

    public void OnSlam(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            //print("slam!");
            slammed = true;
            startedJump = false;
        }
        else if (context.action.phase == InputActionPhase.Canceled)
        {
            slammed = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            //print("jump!");
            jumpButtonHeld = true;
        }
        else if (context.action.phase == InputActionPhase.Canceled)
        {
            // print("cancelled");
            jumpButtonHeld = false;
            startedJump = false;
        }
    }

    void Update()
    {

        float defaultfallGravity = slammed ? slamGravity : fallGravity;
        float playerSpeed = canDash ? dashSpeed : defplayerSpeed;
        float gravityValue = startedJump ? jumpGravity : defaultfallGravity;
        float jumpHeight = minHeight;// jumpCancelled ? minHeight : maxHeight;
        print(defaultfallGravity);
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
            startedJump = false;
        }
        print("isGrounded: " + controller.isGrounded);

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);

        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
        }
        else
        {

            controller.Move(move * Time.deltaTime * playerSpeed);

        }
        print("dash: " + canDash);

        bool tryAccelerate = false;
        float jumpedDistance = transform.position.y - startY;


        if (jumpButtonHeld)
        {
            if (controller.isGrounded)
            {
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
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }
            else if (startedJump && maxHeightExceeded)
            {

                startedJump = false;
            }

        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


}


