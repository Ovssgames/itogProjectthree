using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;
    public float speedRun;
    public float speedRunIsZoom;
    public Animator animator;
    public float animSpeed;

    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    private bool _isClickRightMouse;

    private CharacterController _CharacterController;

    private void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        controllerUp();
        RightMousRun();

    }

    private void RightMousRun()
    {
        _isClickRightMouse = false;

        if (Input.GetMouseButton(1))
        {
            _isClickRightMouse = true;
            speedRun = speedRunIsZoom;
        }
        if(_isClickRightMouse ==false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedRun = 1f;
            }
            else
            {
                speedRun = 0.7f;
            }
        }
    }

    private void controllerUp()
    {
        _moveVector = Vector3.zero;
        var runDirectionw = 0f;
        var runDirectionh = 0f;

        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
            animator.SetTrigger("jump");
        }

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward * speedRun;
            runDirectionh = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward * speedRun;
            runDirectionh = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right * speedRun;
            runDirectionw = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right * speedRun;
            runDirectionw = -1;
        }

        animator.SetFloat("w", runDirectionw, animSpeed, Time.deltaTime);
        animator.SetFloat("h", runDirectionh, animSpeed, Time.deltaTime);
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
