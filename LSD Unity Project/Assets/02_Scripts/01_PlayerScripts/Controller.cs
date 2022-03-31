using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public ParticleSystem bonk;
    public ParticleSystem dust;
    public Material hitMaterial;
    public Material defMaterial;
    Color color;
    Collider capcollider;
    Collider feetCollider;
    public Transform feetTransform;
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
    private float dashSpeed = 70.0f;
    private Vector3 move;
    private float MaxDashTime = 1.7f;
    private float dashStopSpeed = 0.1f;
    private float currentDashTime;
    private bool hasJumped = false;
    private float dropGravity = -65.91f;
    [SerializeField]
    private float jumpGravity = -135.81f;
    [SerializeField]
    private float fallingGravity = -165.81f;
    [SerializeField]
    private float slamGravity = -280f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumpButtonHeld;
    public Vector3 spawnPos;
    private float maxHeight = 6.5f;
    private float minHeight = 2f;
    Ray ray;
    RaycastHit hit;
    bool startedJump;
    float startY;
    private bool slammed = false;
    private bool slamming = false;
    private bool moveTrigger;
    private int rightCount; private int leftCount = 0;
    // if canDash and !dashing then perform dash
    private bool isDashing = false;
    private bool canDash;
    private void Awake()
    {
        feetCollider = feetTransform.GetComponent<Collider>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        color = spriteRender.color;
        anim = gameObject.GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        lifeScript = gameObject.GetComponent<HealthSystem>();
        capcollider = gameObject.GetComponent<Collider>();
        spriteRender.material = defMaterial;
    }
    private void Start()
    {
        controller.enabled = true;
        feetCollider.enabled = true;
        capcollider.enabled = true;
        controller.detectCollisions = true;
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
        if (context.action.triggered) { moveTrigger = true; }
        else if (context.action.phase == InputActionPhase.Canceled) { moveTrigger = false; }
     /*   if (context.action.triggered && movementInput.x < 0)
         
        {  
                leftCount += 1;
                currentDashTime = 0;
            
         
 
            if (leftCount == 1 && !canDash)
            {
                rightCount = 0;
            }
            if (leftCount> 2 | rightCount > 2)
            {
                leftCount = 0;
                rightCount = 0;
            }
        }
        if (context.action.triggered && movementInput.x > 0)
        {
         
                rightCount += 1;
                currentDashTime = 0;
            
            if (rightCount == 1 && !canDash)
            {
                rightCount = 0;
            }
        }*/

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
        controller.detectCollisions = false;
        feetCollider.enabled = false;
        capcollider.enabled = false;
        //controller.enabled = false;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
        yield return new WaitForSeconds(1f);
        this.transform.position = spawnPos;
        capcollider.enabled = true;
        //controller.enabled = true;
        anim.ResetTrigger("Dead");
        for (int i = 0; i < 10; i++)
        {
            spriteRender.material = hitMaterial;
            yield return new WaitForSeconds(0.08f);
            spriteRender.material = defMaterial;
            yield return new WaitForSeconds(0.08f);

        }
        playerRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        invulnerable = false;
        feetCollider.enabled = true;

        controller.detectCollisions = true;

    }


    void Update()
    {
        isColliding = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        bool isAttacked = Physics.CheckSphere(groundCheck.position, groundDistance, feetMask);
        if (isAttacked && !invulnerable)
        {
            bonk.Play();
            startedJump = false;
            if (playerVelocity.y > 0)
            {
                playerVelocity.y += -140f * Time.deltaTime;
                controller.Move(playerVelocity * Time.deltaTime);
            }
            if (playerVelocity.y <= 0)
            {
                playerVelocity.y = 0;
                controller.Move(playerVelocity * Time.deltaTime);
            }
            anim.SetTrigger("Dead");
            StartCoroutine(RespawnPlayer());
            invulnerable = true;
            lifeScript.LoseLife();
           
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
                dust.Play();
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
            dust.Play();
            anim.SetBool("isMoving", true);
            controller.Move(move * Time.deltaTime * playerSpeed);
            if (controller.isGrounded)
            {
                playerVelocity.y = 0;
            }
        }
        if(moveTrigger && movementInput.x < 0)
        {
            leftCount += 1;
        }
        if (moveTrigger && movementInput.x > 0)
        {
            rightCount += 1;
        }
        float startPress = 0;
      if(rightCount == 1 | leftCount ==1)
        {
            startPress += Time.time;
        }
        if (startPress < 2.5f)
            {
            canDash = true;
        }
        if (rightCount == 2 && canDash)
            {
                currentDashTime += dashStopSpeed;
                isDashing = true;
            }
        if (leftCount == 2 && canDash)
        {
            currentDashTime += dashStopSpeed;
            isDashing = true;
        }
        if (currentDashTime >= MaxDashTime && isDashing)
        {
            currentDashTime = MaxDashTime;
            canDash = false;
            isDashing = false;
        }
        
        if (startPress > 1f)
        {
            canDash = false;
            isDashing = false;
            startPress = 0;
        }
        print("left " + leftCount);
        print("right " + rightCount);
        //print(startPress);
        /*    if (leftCount == 2)
            {
                currentDashTime += dashStopSpeed;
                isDashing = true;
            }*/
        /*   if (currentDashTime >= MaxDashTime)
           {
               leftCount = 0;
               rightCount = 0;
               isDashing = false;
               currentDashTime = 0;
           }*/

        //print(currentDashTime);
        /*      if (currentDashTime < MaxDashTime)
              {
                  isDashing = true;
                  currentDashTime += dashStopSpeed * Time.deltaTime;
              }
              if (currentDashTime >= MaxDashTime && isDashing)
              {
                  currentDashTime = MaxDashTime;
                  canDash = false;
                  isDashing = false;
              }*/



        if (tryAccelerate)
        {
            anim.SetBool("isGrounded", false);
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
            anim.SetBool("isGrounded", true);
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




