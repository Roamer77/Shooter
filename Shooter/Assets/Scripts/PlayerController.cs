using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;

    [SerializeField] private float _speed;

    [SerializeField] private float _turnSpeed = 360f;

    private PlayerInput _playerInput;

    public Aiming _aiming;

    public Gun Gun;

    public RollMovement ExternalMovement;
    private Vector3 _leftJoyStickInput;
    private Vector3 _rightJoyStickInput;


    private void GetInput()
    {
        var leftJoyStickInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        var rightJoyStickInput = _playerInput.actions["Aim"].ReadValue<Vector2>();

        _leftJoyStickInput = new Vector3(leftJoyStickInput.x, 0, leftJoyStickInput.y);
        _rightJoyStickInput = new Vector3(rightJoyStickInput.x, 0, rightJoyStickInput.y);
    }

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Aim"].canceled += (ctx) => Gun.MakeDamege();
    }
    void OnDisable()
    {
        _playerInput.actions["Aim"].canceled -= (ctx) => Gun.MakeDamege();
    }
    private void Update()
    {
        GetInput();
        Look(_leftJoyStickInput);
        RotatePlayer(_rightJoyStickInput);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Look(Vector3 input)
    {
        if (input != Vector3.zero)
        {
            var relative = (transform.position + input.ToIso()) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);
        }

    }
    private void RotatePlayer(Vector3 input)
    {
        if (input != Vector3.zero)
        {
            var relative = input.ToIso();
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);

            _aiming.isAming = true;
            _aiming.Aim(transform.rotation, Gun.GetAimDistance().FireDistance);
        }
        else
        {
            _aiming.isAming = false;
        }

    }

    private void Move()
    {
        _player.MovePosition(transform.position + (transform.forward * _leftJoyStickInput.magnitude) * _speed * Time.deltaTime);
    }

}
