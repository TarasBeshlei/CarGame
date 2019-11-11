using System;
using UnityEngine;

public partial class CarMovement : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float turnSpeed = 40f;
    private float jumpHeight = 3f;
    private float reverseRotationDirection = -40f;
    private float normalRotationDirection = 40f;
    private Rigidbody rbd;
    private bool isGrounded;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
       // CarJeep = this.gameObject.GetComponentsInParent();
       rbd = GetComponent<Rigidbody>();
       rbd.freezeRotation = true;
       
    }
    
    void  OnCollisionEnter()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveObject(KeyCode.UpArrow, moveSpeed);
        //MoveObject(KeyCode.DownArrow, -moveSpeed);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("up");
            rbd.AddForce(Vector3.forward * 5f * Time.deltaTime * 10, ForceMode.Acceleration);
        }
        RotateObject(KeyCode.LeftArrow, Vector3.down, turnSpeed);
        RotateObject(KeyCode.RightArrow, Vector3.up, turnSpeed);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            rbd.useGravity = true;
           
            
            isGrounded = false;
        }

    }

    private void RotateObject(KeyCode bindKey, Vector3 rotationDiraction, float speed)
    {
        if (Input.GetKey(bindKey))
        {
           
            transform.Rotate(rotationDiraction * speed * Time.deltaTime);
        }
    }

    private void MoveObject(KeyCode bindKey, float diractionAndSpeed)
    {
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            turnSpeed = reverseRotationDirection;
        } else 
        {
            turnSpeed = normalRotationDirection;
        }
        
        if (Input.GetKey(bindKey))
        {
            rbd.velocity = transform.forward * diractionAndSpeed;
        }

    }
}
