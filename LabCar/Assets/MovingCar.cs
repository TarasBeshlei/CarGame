using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCar : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isOnWater;
    private float distanceToGround = 0.4f;
    private float rotatingSpeed;
    private int jumpHeight = 300;
    private float forwardRotating = 70f;
    private float reverseRotating = -70f;
    private int speed = 800;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Move(KeyCode.UpArrow, speed);
        Move(KeyCode.DownArrow, -speed);
        Rotate(KeyCode.RightArrow, Vector3.up);
        Rotate(KeyCode.LeftArrow, Vector3.down);
        Jump(jumpHeight);
    }

    private void Jump(int jumpHeight)
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, distanceToGround))
        {
            rb.AddForce(transform.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void Rotate(KeyCode bindKey, Vector3 rotateDirection)
    {
        if (Input.GetKey(bindKey) && !isOnWater)
        {
            transform.Rotate(rotateDirection * rotatingSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotatingSpeed = reverseRotating;
        }
        else
        {
            rotatingSpeed = forwardRotating;
        }
    }

    private void Move(KeyCode bindKey, int speedAndDirection)
    {
        if (Input.GetKey(bindKey) && !isOnWater)
        {
            rb.AddForce(transform.forward * speedAndDirection * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        if (collision.gameObject.name == "Water")
        {
            isOnWater = true;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name != "Water")
        {
            isOnWater = false;
        }
    }
}
