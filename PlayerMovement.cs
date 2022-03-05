using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    private float groundedVerticalVelocity = -2f;
    [SerializeField] public LayerMask groundMask;
    bool isGrounded;
    bool jump;

    Vector3 verticalVelocity = Vector3.zero;

    Vector2 horizontalInput;


    public void ReceiveHorizontalInput(Vector2 _horizontalInput) {
        horizontalInput = _horizontalInput;
    }

    public void ReceiveJump() {
        jump = true;
    }

    void Update()
    {
        // ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && verticalVelocity.y < 0) {
            // calculate grounded vertical velocity y by applying steady grounded force
            verticalVelocity.y = groundedVerticalVelocity;
        }

        // jump
        if (jump) {
            if (isGrounded) {
                // calculate vertical velocity y using jump formula
                verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            // reset jump
            jump = false;
        }
        
        // calculate vertical velocity y using gravity
        verticalVelocity.y += gravity * Time.deltaTime;

        // apply vertical movement
        controller.Move(verticalVelocity * Time.deltaTime);

        // calculate x and z using horizontal input vector
        float x = horizontalInput.x;    
        float z = horizontalInput.y;
        
        // calculate horizontal movement using x and z
        Vector3 horizontalMovement = transform.right * x + transform.forward * z;

        // apply horizontal movement
        controller.Move(horizontalMovement * speed * Time.deltaTime);
    }
}
