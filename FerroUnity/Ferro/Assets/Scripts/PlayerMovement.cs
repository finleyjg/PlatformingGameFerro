using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private Vector3 movementDirection = Vector3.zero;
    private Animator anim;
    private Rigidbody rb;
    public float movementSpeed = 10f; 
    public float rotationSpeed = 10f;
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
        CharacterMovement();
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

    void CharacterMovement()
    {
        if (movementDirection.magnitude > 0)
        {
            Vector3 move = transform.TransformDirection(movementDirection) * movementSpeed * Time.deltaTime;
            //deltatime ensures the player moves at a consistent speed independent of frame rate
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


}
