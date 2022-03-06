using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    /*public Transform groundCheck;
    public bool isColliding;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool rayGrounded;*/
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private InputActionReference actionReference;

    private float defplayerSpeed = 12.0f;
    private float dashSpeed = 25.0f;

    private float distToGround;

    private float MaxDashTime = 1.5f;
    private float dashStopSpeed = 0.1f;
    private float currentDashTime;
    private float jumpGravity = -40.81f;
    private float fallGravity = -48.81f;
    private float slamGravity = -160f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumpButtonHeld;

    private float maxHeight = 5.5f;
    private float minHeight = 2f;
    Ray ray;
    RaycastHit hit;
    bool startedJump;
    float startY;
    private bool slammed = false;

    // if canDash and !dashing then perform dash
    private bool isDashing = false;
    private bool canDash;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    private void Start()
    {
        currentDashTime = MaxDashTime;
    }

    IEnumerator CancelDash()
    {
        yield return new WaitForSeconds(1.5f);
        canDash = false;
        currentDashTime = MaxDashTime;

    }
    public void OnDash(InputAction.CallbackContext context)
    {
        //print(gameObject.name);
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
                StartCoroutine(CancelDash());
            }
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
    /*private void FixedUpdate()
    {*/
    //ray.origin = transform.position;
    /* if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Platform")
     {
         Debug.Log(hit.transform.tag);
         rayGrounded = true;
     }
     else { rayGrounded = false; }*/

    /*        isColliding = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isColliding)
            {
                Debug.Log("is colliding");
                rayGrounded = true;
            }
            else { rayGrounded = false; }*/
    // }
    void Update()
    {
        /*   int layer = 6;
           int layerMask = 1 << layer;
           //layerMask = ~layerMask;
           ray.origin = transform.position;
           ray.direction = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
           if (Physics.Raycast(ray, out hit, 0.3f, layerMask))
           {
               Debug.Log(hit.transform.tag);
               rayGrounded = true;
           }
           else { rayGrounded = false; }*/
        /*     Vector3 raydirection = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
             if (!Physics.Raycast(transform.position, raydirection, distToGround + 0.05f, layerMask))
             {
                 rayGrounded = true;
             }
             else
             {
                 rayGrounded = false;
             }*/
        //Debug.Log(rayGrounded);
        //Debug.Log("Ray Hit: " + hit.transform.name);
        Debug.DrawRay(transform.position, ray.direction, Color.red);
        float defaultfallGravity = slammed ? slamGravity : fallGravity;
        float playerSpeed = isDashing ? dashSpeed : defplayerSpeed;
        float gravityValue = startedJump ? jumpGravity : defaultfallGravity;
        float jumpHeight = minHeight;// jumpCancelled ? minHeight : maxHeight;

        //print("isGrounded: " + controller.isGrounded);

        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);

        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
        }
        else
        {
            // if (controller.isGrounded)
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        if (canDash && !isDashing)
        {
            currentDashTime = 0;
        }
        if (currentDashTime < MaxDashTime)
        {
            isDashing = true;
            currentDashTime += dashStopSpeed * Time.deltaTime;
        }
        if (currentDashTime >= MaxDashTime && isDashing)
        {
            currentDashTime = MaxDashTime;
            canDash = false;
            isDashing = false;
        }


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
            else if (startedJump && !controller.isGrounded)
            {
                startedJump = false;
                Debug.Log("ceiling");
            }

        }
        if (playerVelocity.y > 0)
        {
            canDash = false;
            /*  if (controller.detectCollisions == true)
              {
                  startedJump = false;
              }*/
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(controller.isGrounded + "startedjump" + startedJump);
    }

}




