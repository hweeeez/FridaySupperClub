using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    SpriteRenderer spriteRender;
    Animator anim;
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

    private bool invulnerable = false;
    private float defplayerSpeed = 14.0f;
    private float dashSpeed = 25.0f;
    private Vector3 move;
    private float MaxDashTime = 1.5f;
    private float dashStopSpeed = 0.1f;
    private float currentDashTime;
    private bool hasJumped = false;
    private float dropGravity = -60.91f;
    private float jumpGravity = -85.81f;
    private float fallingGravity = -95.81f;
    private float slamGravity = -280f;
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
    private bool slamming = false;

    // if canDash and !dashing then perform dash
    private bool isDashing = false;
    private bool canDash;
    private void Awake()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
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
            slamming = true;
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
        controller.enabled = false;
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1.1f);
        this.transform.position = spawnPos;
        anim.ResetTrigger("Dead");
        playerRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        yield return new WaitForSeconds(1f);
        invulnerable = false;
        controller.enabled = true;

    }


    void Update()
    {
        print(lifeScript.health);
        //ceilingcheck
        isColliding = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        bool isAttacked = Physics.CheckSphere(groundCheck.position, groundDistance, feetMask);
        if (isAttacked && !invulnerable)
        {
            Debug.Log("attacked");
            anim.SetTrigger("Dead");
            invulnerable = true;
            lifeScript.LoseLife();
            StartCoroutine(RespawnPlayer());
        }

        float fallGravity = hasJumped ? fallingGravity : dropGravity;
        float defaultfallGravity = slammed ? slamGravity : fallGravity;
        float playerSpeed = isDashing ? dashSpeed : defplayerSpeed;
        float gravityValue = startedJump ? jumpGravity : defaultfallGravity;
        float jumpHeight = minHeight;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        //print("isGrounded: " + controller.isGrounded);
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

        move = new Vector3(movementInput.x, movementInput.y, 0);

        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
            controller.Move(move * Time.deltaTime * playerSpeed);
            if (controller.isGrounded)
            {
                playerVelocity.y = 0;
            }
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
            hasJumped = true;
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
        else if (controller.isGrounded && !tryAccelerate)
        {
            hasJumped = false;
            slamming = false;
            playerVelocity.y = 0;
        }
        if (playerVelocity.y > 0)
        {
            canDash = false;

        }
        if (slamming && !controller.isGrounded)
        {
            anim.SetBool("slam", true);
        }
        else if (controller.isGrounded) { anim.SetBool("slam", false); }
        if (playerVelocity.y > 0)
        {
            anim.SetBool("isGrounded", false);
        }
        else
        { anim.SetBool("isGrounded", true); }

        if (movementInput.x > 0)
        {
            spriteRender.flipX = false;
        }
        if (movementInput.x < 0)
        {
            spriteRender.flipX = true;
        }
        if (lifeScript.health == 0)
        {
            StartCoroutine(finalDeath());
        }
        Debug.Log("pvy");
        Debug.Log(playerVelocity.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            lifeScript.health = 0;
        }
    }
    IEnumerator finalDeath()
    {
        controller.enabled = false;
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        anim.Play("death");
        yield return new WaitForSeconds(0.9f);
        Destroy(this.gameObject);
    }
}




