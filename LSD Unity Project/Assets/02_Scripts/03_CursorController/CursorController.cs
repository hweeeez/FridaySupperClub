using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CursorController : MonoBehaviour
{
    private float timeInactive;
    [SerializeField]
    private InputAction mouseClick;
    public Texture2D cursor;
    public Texture2D cursorClicked;
    private AutoGen controls;
    private Camera mainCamera;
    private Vector3 lastPos;
    private Vector3 currentPos;
    private float mouseActiveTime = 0f;
    private bool isMoving;
    private Vector2 mouseInput;
    // Start is called before the first frame update
    void Awake()
    {
        lastPos = transform.position;
        controls = new AutoGen();
        mainCamera = Camera.main;
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnEnable()
    {
        controls.Enable();
        mouseClick.Enable();

    }
    private void OnDisable()
    {
        controls.Disable();
        mouseClick.Disable();

    }
    private void Start()
    {
        controls.Player1.MouseClick.started += _ => StartedClick();
        controls.Player1.MouseClick.performed += _ => EndedClick();
    }
    public void OnMousePosition(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }
    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);

    }
    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

     void Update()
    {
        
        var mousePosition = controls.asset["MousePosition"].ReadValue<Vector2>();
        currentPos = mousePosition;
        if (currentPos != lastPos)
        {
            //StopCoroutine(HideCursor());
            timeInactive = 0;
            Cursor.visible = true; Cursor.lockState = CursorLockMode.None; 
            
        }
        else { timeInactive += Time.deltaTime;
            if (timeInactive > 2f) { Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; } }

        lastPos = currentPos;
    }
  
}
