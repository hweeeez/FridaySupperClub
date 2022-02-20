using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections;
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
    private float dashSpeed = 10.0f;

    public float MaxDashTime = 1.0f;
    public float dashStopSpeed = 0.1f;
    private float currentDashTime;
    public int tapCount;
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

    private bool dashing = false;
    private bool canDash;
    public float xDir;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
          }
    private void Start()
    {
        currentDashTime = MaxDashTime;
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        /*     if (!actionReference.action.interactions.Contains("MultiTap"))
             {
                 return;
             }*/
        if (actionReference.action.triggered)
        {
            if (context.interaction is MultiTapInteraction)
            {
                Debug.Log("triggered");
                canDash = true;
            }
        }
        if (context.action.phase == InputActionPhase.Canceled)
        {
            if (context.interaction is MultiTapInteraction)
            {
                canDash = false;
                currentDashTime = MaxDashTime;
                Debug.Log("cancel");
            }
        }
    
    }
    IEnumerator Dashing()
    {
        if (currentDashTime < MaxDashTime && dashing)
        {
            playerVelocity = Vector2.left * dashSpeed;
            currentDashTime += dashStopSpeed;
            yield return null;
        }
        if (currentDashTime >= MaxDashTime && dashing == true)
        {
            currentDashTime = MaxDashTime;
            canDash = false;
            dashing = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
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
            jumpButtonHeld = true;
        }
        else if (context.action.phase == InputActionPhase.Canceled)
        {
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
    
        if (controller.isGrounded == true && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
            startedJump = false;
        }
        //print("isGrounded: " + controller.isGrounded);

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);

        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
        }
        else
        {
            if (!canDash && !dashing)
            {
                controller.Move(move * Time.deltaTime * playerSpeed);
         
            }
            if (canDash)
            {

                if (Keyboard.current.aKey.wasPressedThisFrame)
                {
                    currentDashTime = 0;
                    dashing = true;
                }
          
                /*  if (Keyboard.current.sKey.wasPressedThisFrame)
                  {
                      currentDashTime = 0f;
                      if (currentDashTime < MaxDashTime)
                      {
                          playerVelocity = Vector2.right * dashSpeed;
                          currentDashTime += dashStopSpeed;

                      }
                      if (currentDashTime == MaxDashTime)
                      {
                          canDash = false;
                      }
                  }*/
            }

        }
     /*   if (currentDashTime < MaxDashTime && dashing)
        {
            playerVelocity = Vector2.left * dashSpeed;
            currentDashTime += dashStopSpeed;
        }
      if (currentDashTime >= MaxDashTime && dashing == true)
        {
            currentDashTime = MaxDashTime;
            canDash = false;
            dashing = false;
        }*/
        print(dashing);
        print(currentDashTime);
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


