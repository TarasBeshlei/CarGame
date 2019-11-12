using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    public float range = 5f;
    public float moveSpeed = 3f;
    public float turnSpeed = 40f;
    public float jump = 8f;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 3f;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            obj.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                obj.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                obj.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            obj.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                obj.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        
            if (Input.GetKey(KeyCode.RightArrow))
            {
                obj.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            obj.transform.Translate(Vector3.up * jump * Time.deltaTime);
        }

        
    }
}
