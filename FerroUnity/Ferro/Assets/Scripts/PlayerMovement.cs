using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float movementSpeed = 5f; 
    public float rotationSpeed = 10f; 
    private Vector3 movementDirection = Vector3.zero;
    private Animator anim;
    private Rigidbody rb;

    private RobotFreeAnim robotAnim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        robotAnim = GetComponent<RobotFreeAnim>(); 
    }

    void Update()
    {
        GetInput();
        HandleMovement();
        HandleRotation();
    }

    void GetInput()
    {
        //wasd
        movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            movementDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            movementDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            movementDirection += Vector3.right;
        }

        movementDirection.Normalize(); //keeps same  speed
    }

    void HandleMovement()
    {
        if (movementDirection.magnitude > 0)
        {
            Vector3 move = transform.TransformDirection(movementDirection) * movementSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + move);
            anim.SetBool("Walk_Anim", true);
            anim.speed = 1.25f; //to make the animation a little faster
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
            anim.speed = 1f; //normal speed animation and walking animation stop
        }
    }

    void HandleRotation()
    {
        if (movementDirection.magnitude > 0)
        {
            float targetRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotationQuat = Quaternion.Euler(0f, targetRotation, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationQuat, rotationSpeed * Time.deltaTime);
        }
    }
}
