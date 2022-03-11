using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CursorController : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClick;
    public Texture2D cursor;
    public Texture2D cursorClicked;
    private AutoGen controls;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Awake()
    {

        controls = new AutoGen();
        mainCamera = Camera.main;
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnEnable()
    {
        controls.Enable();
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }
    private void OnDisable()
    {
        controls.Disable();
        mouseClick.Disable();
        mouseClick.performed -= MousePressed;
    }
    private void Start()
    {
        controls.Player1.MouseClick.started += _ => StartedClick();
        controls.Player1.MouseClick.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }
    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
    }
    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Player1.MousePosition.ReadValue<Vector2>());
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null)
        {
            IClick click = hits2D.collider.gameObject.GetComponent<IClick>();
            if (click != null) click.onClickAction();
            Debug.Log("Hit 2D Collider" + hits2D.collider.tag);

        }
        /* Ray ray = mainCamera.ScreenPointToRay(controls.Player1.MousePosition.ReadValue<Vector2>());
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit))
         {
             if (hit.collider != null)
             {
                 Debug.Log("3D Hit: +hit.collider.tag");
             }
         }*/

        /* RaycastHit[] hits = Physics.RaycastAll(ray, 200);
  for (int i = 0; i < hits.Length; ++i)
         {
             if (hits[i].collider != null)
             {
                 Debug.Log("3D Hit All:" + hits[i]);
             }
         }
         Physics.RaycastAll(ray, 200);
     */
    }
    // Update is called once per frame
    void Update()
    {

        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        if (Input.mousePosition == null)
        {
            StartCoroutine(HideCursor());
        }
        else { Cursor.visible = true; }
    }
    private IEnumerator HideCursor()
    {
        yield return new WaitForSeconds(1);
        Cursor.visible = false;
    }
}
