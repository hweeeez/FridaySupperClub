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

    public GameObject currentHitObject;
    public float currentHitDistance;
    private Vector3 origin;
    private Vector3 direction;

    public float sphereRadius;
    public float maxDist;
    public LayerMask layerMask;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();

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
        origin = transform.position;
        direction = -transform.up;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDist, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            // print(currentHitObject + "hobj");
        }
        else
        {
            currentHitDistance = maxDist;
            currentHitObject = null;
        }
        float defaultfallGravity = slammed ? slamGravity : fallGravity;

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
        controller.Move(move * Time.deltaTime * playerSpeed);


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
        print(slammed);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }

}


