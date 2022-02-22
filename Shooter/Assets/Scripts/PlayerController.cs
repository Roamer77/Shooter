using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;

    [SerializeField] private float _speed;

    [SerializeField] private float _turnSpeed = 360f;

    [SerializeField] private FixedJoystick _joystick;

    public RollMovement ExternalMovement;
    private Vector3 _input;

    private void GetInput()
    {
        _input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
    }

    private void Update()
    {
        GetInput();
        Look();
    }

    private void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            ExternalMovement.Roll();
            return;
        }
        Move();    
    }

    private void Look()
    {
        if (_input != Vector3.zero)
        {
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);
        }

    }
    private void Move()
    {
        _player.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
  
}
