using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Gravity = 9.8f;
    public float JumpForce;

    private float _fallVelocity = 0;
    private CharacterController _CharacterController;

    private void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        } 
            
        
    }

    private void FixedUpdate()
    {
        _CharacterController.Move(Vector3.forward * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _CharacterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

    }


}
