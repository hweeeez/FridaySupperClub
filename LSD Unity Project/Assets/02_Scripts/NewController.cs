using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewController : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    private bool _grounded;
    private int _groundLayer = 1 << 6;
    private InputAction _moveAction;
    private AutoGen _defaultPlayersActions;
    private Rigidbody _rigidbody;
    private float _speed = 8f;
    private float _jumpForce = 6f;
    private bool groundedPlayer;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _defaultPlayersActions = new AutoGen();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        _moveAction = _defaultPlayersActions.Player1.Movement;
        _moveAction.Enable();


        _defaultPlayersActions.Player1.Jump.performed += OnJump;
        _defaultPlayersActions.Player1.Jump.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _defaultPlayersActions.Player1.Jump.Disable();
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (_grounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        Debug.Log("Jump!");
    }
    private void FixedUpdate()
    {
        _grounded = Physics.Raycast(
           _groundCheck.position, Vector3.down, 0.05f);
        Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        Debug.Log($"Moving, direction = {moveDir}");
        Vector3 vel = _rigidbody.velocity;
        vel.x = _speed * moveDir.x;
        vel.z = _speed * moveDir.y;
        _rigidbody.velocity = vel;
    }
}

