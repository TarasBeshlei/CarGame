using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScropt : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    private float distToGround = 0.4f;
    private float rotatingSpeed = 70f;
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
        Jump(200);
    }

    private void Jump(int jumpHeight)
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, distToGround))
        {
            rb.AddForce(transform.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void Rotate(KeyCode bindKey, Vector3 rotateDirection)
    {
        if (Input.GetKey(bindKey))
        {
            transform.Rotate(rotateDirection * rotatingSpeed * Time.deltaTime);
        }
    }

    private void Move(KeyCode bindKey, int speedAndDirection)
    {
        if (Input.GetKey(bindKey))
        {
            rb.AddForce(transform.forward * speedAndDirection * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotatingSpeed = -70f;
        }
        else
        {
            rotatingSpeed = 70f;
        }
    }
}
