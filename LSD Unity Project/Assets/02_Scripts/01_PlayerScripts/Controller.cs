using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private bool rayGrounded;
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
    private float jumpGravity = -35.81f;
    private float fallGravity = -40.81f;
    private float slamGravity = -130f;
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
        rayGrounded = true;
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
    private void FixedUpdate()
    {
        ray.origin = transform.position;
        ray.direction = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Platform")
        {
            Debug.Log(hit.transform.tag);
            rayGrounded = true;
        }
        else { rayGrounded = false; }
        /*   if (!Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
           {
               rayGrounded = false;
           }
           else
           {
               rayGrounded = true;
           }*/
    }
    void Update()
    {
    /*    ray.origin = transform.position;
        ray.direction = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Platform")
        {
            Debug.Log(hit.transform.tag);
            rayGrounded = true;
        }
        else { rayGrounded = false; }*/
        Debug.Log(rayGrounded);
        Debug.DrawRay(transform.position, Vector3.down,  Color.red);
        float defaultfallGravity = slammed ? slamGravity : fallGravity;
        float playerSpeed = isDashing ? dashSpeed : defplayerSpeed;
        float gravityValue = startedJump ? jumpGravity : defaultfallGravity;
        float jumpHeight = minHeight;// jumpCancelled ? minHeight : maxHeight;
 
        //print("isGrounded: " + controller.isGrounded);

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);

        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
        }
        else
        {
            if (rayGrounded) { controller.Move(move * Time.deltaTime * playerSpeed); }
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
            if (rayGrounded)
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
    }

}




