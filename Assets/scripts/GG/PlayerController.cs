using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;

    private float _fallVelocity = 0;
    private Vector3 _moveVector;

    private CharacterController _CharacterController;

    private void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        _moveVector = Vector3.zero;
        
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }


        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }


    }

    private void FixedUpdate()
    {
        if (_CharacterController.isGrounded && _fallVelocity>0)
        {
            _fallVelocity = 0;
        }


        _CharacterController.Move(_moveVector * Time.fixedDeltaTime * Speed);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _CharacterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

    }

        
}
