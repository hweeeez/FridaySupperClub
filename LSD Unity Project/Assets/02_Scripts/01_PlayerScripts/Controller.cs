using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    Rigidbody playerRB;
    public bool groundcheck;
    public Transform groundCheck;
    public bool isColliding;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask feetMask;
    private bool rayGrounded;
    private CharacterController controller;
    private HealthSystem lifeScript;
    private Vector3 playerVelocity;
    [SerializeField]
    private InputActionReference actionReference;

    private float defplayerSpeed = 14.0f;
    private float dashSpeed = 25.0f;
    private Vector3 move;
    private float MaxDashTime = 1.5f;
    private float dashStopSpeed = 0.1f;
    private float currentDashTime;
    private float jumpGravity = -40.81f;
    private float fallGravity = -48.81f;
    private float slamGravity = -100f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumpButtonHeld;
    public Vector3 spawnPos;
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
        playerRB = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        lifeScript = gameObject.GetComponent<HealthSystem>();
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
            print("jumping");
            jumpButtonHeld = true;
        }
        else if (context.action.phase == InputActionPhase.Canceled)
        {
            jumpButtonHeld = false;
            startedJump = false;
        }
    }
    IEnumerator RespawnPlayer()
    {
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1f);
        this.transform.position = spawnPos;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        yield return new WaitForSeconds(0.5f);

    }


    void Update()
    {

        //ceilingcheck
        isColliding = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        bool isAttacked = Physics.CheckSphere(groundCheck.position, groundDistance, feetMask);
        if (isAttacked)
        {
            lifeScript.LoseLife();
            StartCoroutine(RespawnPlayer());
        }

        Debug.DrawRay(transform.position, ray.direction, Color.red);
        float defaultfallGravity = slammed ? slamGravity : fallGravity;
        float playerSpeed = isDashing ? dashSpeed : defplayerSpeed;
        float gravityValue = startedJump ? jumpGravity : defaultfallGravity;
        float jumpHeight = minHeight;// jumpCancelled ? minHeight : maxHeight;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        //print("isGrounded: " + controller.isGrounded);
        bool tryAccelerate = false;
        float jumpedDistance = transform.position.y - startY;

        print(playerVelocity.y);
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

        move = new Vector3(movementInput.x, movementInput.y, 0);

        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
        }
        else
        {
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
            if (startedJump && isColliding)
            {
                startedJump = false;
                playerVelocity.y = 0;
            }

        }
        if (controller.isGrounded)
        {
            slammed = false;
        }
        if (playerVelocity.y > 0)
        {
            canDash = false;
            /*  if (controller.detectCollisions == true)
              {
                  startedJump = false;
              }*/
        }


    }

}




