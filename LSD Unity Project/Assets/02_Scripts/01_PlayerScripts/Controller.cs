using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed = 3.0f;

    [SerializeField] private Transform[] _sensors;
    [SerializeField] private LayerMask _groundCheckLayerMask;
    [SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private Color _groundHit;
    [SerializeField] private Color _groundMiss;

    //private float gravityValue = -9.81f;
    [SerializeField]
    private float jumpGravity = -11.81f;
    [SerializeField]
    private float fallGravity = -15.81f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumpButtonHeld;
    public float buttonTime = 0.75f;

    private float maxHeight = 2f;
    private float minHeight = 1f;
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
        isGrounded = RaycastFromAllSensors();
        float gravityValue = jumpGravity;// startedJump &&  ? jumpGravity : fallGravity;
        float jumpHeight = minHeight;// jumpCancelled ? minHeight : maxHeight;
        bool debugGrounded = true;
        //grounded
        if (isGrounded)
        {
            playerVelocity.y = -0.5f;
            startedJump = false;
        }
        print("isGrounded: " + isGrounded);

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        bool tryAccelerate = false;
        float jumpedDistance = transform.position.y - startY;
        //print(startedJump + "startedJump");
        //print(jumpedDistance + "jumpeddistance");

        if (jumpButtonHeld)
        {
            if (isGrounded)
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
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue) * Time.deltaTime * 10;
            }
            if (startedJump && maxHeightExceeded)
                playerVelocity.y = 0;
        }
        /* if (!jumped && jumping == true)
         {
             playerVelocity.y = 2;
         }*/
        /*       if (jumping)
               {

                   jumpTime += Time.deltaTime;
                   if (!jumped)
                   {
                       jumpCancelled = true;
                   }

                   if (jumpTime > buttonTime)
                   {
                       jumping = false;
                   }
               }

               if (jumpCancelled && jumping && playerVelocity.y > 0)
               {

                       playerVelocity.y = 0;

               }*/
        /* Debug.Log(jumping);
         Debug.Log(jumped);*/
        //Debug.Log(playerVelocity.y);
        //Debug.Log(jumpHeight);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private bool RaycastFromSensor(Transform sensor)
    {
        RaycastHit2D hit;
        var position = sensor.position;
        var forward = sensor.forward;
        hit = Physics2D.Raycast(position, forward, _groundCheckDistance, _groundCheckLayerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(position, forward * _groundCheckDistance, _groundHit);
            return true;
        }
        else
        {
            Debug.DrawRay(position, forward * _groundCheckDistance, _groundMiss);
        }
        return false;
    }
    private bool RaycastFromAllSensors()
    {
        foreach (var sensor in _sensors)
        {
            if (RaycastFromSensor(sensor)) return true;
        }
        return false;
    }
}


