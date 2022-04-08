using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public static List<Collider> playerColliders = new List<Collider>();
    #region
    public static bool dead;
    public ParticleSystem bonk;
    public ParticleSystem dust;
    public Material hitMaterial;
    public Material defMaterial;
    Collider headCollider;
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
    private float MaxDashTime = 1.4f;
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
    float mass = 3.0f;
    Vector3 impact = Vector3.zero;
    bool startedJump;
    float startY;
    private bool slammed = false;
    private bool slamming = false;
    private bool moveTrigger;
    private int rightCount; private int leftCount = 0;
    // if canDash and !dashing then perform dash
    private bool isDashing = false;
    private bool canDash;
    private bool canMove = true;
    bool canJump = true; bool tryAccelerate = false; bool confine = false;
    #endregion
    public LayerMask collisionMask;
    RaycastOrigins raycastOrigins;
    const float skinWidth = 0.12f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    float horizontalRaySpacing;
    float verticalRaySpacing;
    public CollisionInfo collisions;
    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;


        public Vector3 velocityOld;
        public float angle;
        public Vector2 point;
        public bool isTrigger;
        public List<string> bottomRayTags;
        public void Reset()
        {
            above = below = false;
            left = right = false;

            isTrigger = false;

            angle = 0;
            point = Vector2.zero;
            bottomRayTags = new List<string>();
        }
    }

    private void Awake()
    {
        headCollider = groundCheck.GetComponent<Collider>();
        feetCollider = feetTransform.GetComponent<Collider>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        lifeScript = gameObject.GetComponent<HealthSystem>();
        capcollider = gameObject.GetComponent<Collider>();
        playerColliders.Add(capcollider);

        spriteRender.material = defMaterial;
    }
    private void Start()
    {
        CalculateRaySpacing();
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
        #region
        // if (context.action.triggered) { moveTrigger = true; }
        // else if (context.action.phase == InputActionPhase.Canceled) { moveTrigger = false; }
        /* if (context.action.triggered && movementInput.x < 0)

         {
             leftCount += 1;
             currentDashTime = 0;



             if (leftCount == 1 && !canDash)
             {
                 rightCount = 0;
             }
             if (leftCount > 2 | rightCount > 2)
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
        #endregion
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
        Vector3 down = new Vector3(0, -1, 0);
        controller.Move(down * Time.deltaTime * 80f);
        playerVelocity.y = 0;
        controller.Move(playerVelocity * Time.deltaTime);
        canMove = false;
        AddImpact(Vector3.down, 30);
        headCollider.enabled = false;
        confine = true;
        canJump = false;
        invulnerable = true;
        tryAccelerate = false;
        controller.detectCollisions = false;
        feetCollider.enabled = false;
        // capcollider.enabled = false;
        // controller.enabled = false;
        // playerRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;  
        yield return new WaitForSeconds(0.5f);
        controller.enabled = false;
        this.transform.position = spawnPos;
        yield return new WaitForSeconds(0.5f);
        canJump = true;
        canMove = true;
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
        confine = false;
        headCollider.enabled = true;

    }
    void UpdateRaycastOrigins()
    {
        Bounds bounds = capcollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }
    void VerticalCollisions()
    {
        collisions.bottomRayTags = new List<string>();
        bool anyhit = false;
        GameObject hitGo = null;
        float directionY = Mathf.Sign(playerVelocity.y);
        float rayLength = Mathf.Abs(playerVelocity.y) + skinWidth;
        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + playerVelocity.x);
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Vector2.up * directionY, out hit, rayLength, collisionMask))
            {

                //playerVelocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                anyhit = true;
                hitGo = hit.collider.gameObject;
                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
                collisions.angle = Vector2.Angle(hit.normal, Vector2.right);
                collisions.point = hit.point;


                if ((directionY == 1 && (hit.collider.tag == "Platform")))
                {
                    Physics.IgnoreCollision(hit.collider, capcollider, true);
                    print("hit");
                    collisions.above = false;
                    continue;
                }
                else
                {
                    if (directionY == -1)
                    {
                        Physics.IgnoreCollision(hit.collider, capcollider, false);
                        collisions.bottomRayTags.Add("NONE");
                    }
                }
            }
        }
    }
    void CalculateRaySpacing()
    {
        Bounds bounds = capcollider.bounds;
        bounds.Expand(skinWidth * -2);

        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);

    }
    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }


    void Update()
    {
        // print(playerVelocity.y);

        bool tryAccelerate = false;
        // isColliding = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        bool isAttacked = Physics.CheckSphere(groundCheck.position, groundDistance, feetMask);

        float fallGravity = canJump ? fallingGravity : dropGravity;
        float defaultfallGravity = slammed ? slamGravity : fallGravity;
        float playerSpeed = isDashing ? dashSpeed : defplayerSpeed;
        float gravityValue = startedJump ? jumpGravity : defaultfallGravity;
        float jumpHeight = minHeight;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        //print("isGrounded: " + controller.isGrounded);
        float jumpedDistance = transform.position.y - startY;

        UpdateRaycastOrigins();
        collisions.Reset();
        VerticalCollisions();
        if (playerVelocity.y != 0)
        {
            VerticalCollisions();
        }

        if (jumpButtonHeld && canJump)
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



        if (movementInput == Vector2.zero)
        {
            move = Vector3.zero;
            anim.SetBool("isMoving", false);
        }
        else if (canMove)

        {
            dust.Play();
            anim.SetBool("isMoving", true);
            move = new Vector3(movementInput.x, movementInput.y, 0);
            controller.Move(move * Time.deltaTime * playerSpeed);
            if (controller.isGrounded)
            {
                playerVelocity.y = 0;
            }
        }
        #region
        /*  if (moveTrigger && movementInput.x < 0)
          {
              leftCount += 1;
          }
          if (moveTrigger && movementInput.x > 0)
          {
              rightCount += 1;
          }*/

        //confirm
        /*float startPress = 0;
         if (rightCount == 1 | leftCount == 1)
         {
             startPress += Time.time;
         }
         if (startPress < 0.5f)
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
         }*/


        /*if (isDashing)
        {
            //canDash = false;
            if (rightCount == 2)
            {
                if (movementInput.x == -1)
                {
                    isDashing = false;
                }
            }
            if (leftCount == 2)
            {
                if (movementInput.x == 1)
                {
                    isDashing = false;
                }
            }

        }*/

        //confirm
        /* if (startPress > 1f)
         {
             canDash = false;
             isDashing = false;
             startPress = 0;
         }*/
        /*      if (leftCount == 1 && rightCount == 1)
              {
                  if (movementInput.x == 1)
                  {
                      leftCount = 0;
                  }
                  if (movementInput.x == -1)
                  {
                      rightCount = 0;
                  }
              }*/
        //print("left " + leftCount);
        // print("right " + rightCount);
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

        #endregion

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
        if (isAttacked && !invulnerable)
        {
            if (impact.magnitude > 0.2F) controller.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

            if (!confine)
            {
                canMove = false;
                tryAccelerate = false;
                canJump = false;
                bonk.Play();
                startedJump = false;

                anim.SetTrigger("Dead");
                StartCoroutine(RespawnPlayer());
                lifeScript.LoseLife();
            }
        }

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
    void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }
    IEnumerator finalDeath()
    {
        Vector3 down = new Vector3(0, -1, 0);
        controller.Move(down * Time.deltaTime * 10f);
        playerVelocity.y = 0;
        controller.Move(playerVelocity * Time.deltaTime);
        canMove = false;
        AddImpact(Vector3.down, 10);
        headCollider.enabled = false;
        controller.detectCollisions = false;
        feetCollider.enabled = false;
        canJump = false;
        //controller.enabled = false;
        //playerRB.constraints = RigidbodyConstraints.FreezeAll;
        anim.Play("death");
        yield return new WaitForSeconds(0.9f);
        this.gameObject.SetActive(false);
        VictoryScreen vicSc = GameObject.Find("VictoryManager").GetComponent<VictoryScreen>();
        this.transform.position = vicSc.selectedPoint.transform.position;
    }
    private void OnDestroy()
    {
        playerColliders.Remove(capcollider);
    }
}





