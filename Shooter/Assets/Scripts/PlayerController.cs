using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;

    [SerializeField] private float _speed;

    [SerializeField] private float _turnSpeed = 360f;

    [SerializeField] private FixedJoystick _leftJoystick;
    [SerializeField] private FixedJoystick _rightJoystick;

    public Aiming _aiming;
    public GameObject AimPoint;

    public Shooting Shooting;
    public RollMovement ExternalMovement;
    private Vector3 _input;
    private Vector3 _rightJSInput;


    private void GetInput()
    {
        _input = new Vector3(_leftJoystick.Horizontal, 0, _leftJoystick.Vertical);
        _rightJSInput = new Vector3(_rightJoystick.Horizontal, 0, _rightJoystick.Vertical);
    }

    private void Update()
    {
        GetInput();
        Look(_input); 
        RotatePlayer(_rightJSInput);  
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
            
            AimPoint.transform.position = transform.TransformPoint(0,0,4);
            _aiming.isAming = true;
            _aiming.Aim(transform.rotation, AimPoint.transform.position);
        }
        else{
           _aiming.isAming = false; 
           Shooting.Shoot(_aiming.Ray,_aiming.Distance);
        }
        
    }

    private void Move()
    {
        _player.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
  
}
