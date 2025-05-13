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


    public bool isGrounded = true;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public GyroJumpSound gyroJumpSound;

    void FixedUpdate()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
        //allows for short hop jumping, as well as realistic and responsive gravity simulation
    }




    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        robotAnim = GetComponent<RobotFreeAnim>();
    }

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        CharacterMovement();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            gyroJumpSound.PlayJumpSound();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = true;
        }
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
        Vector3 move = movementDirection * movementSpeed * Time.deltaTime;
        Vector3 targetPosition = rb.position + transform.TransformDirection(move);
        rb.MovePosition(targetPosition);

        if (!isGrounded)
        {
            anim.SetBool("Walk_Anim", false); //Stops walk animation when jumping
            anim.speed = 0f;                  //freeze
        }
        else
        {
            if (movementDirection.magnitude > 0)
            {
            anim.SetBool("Walk_Anim", true);
            anim.speed = 1.25f;
            }
            else
            {
            anim.SetBool("Walk_Anim", false);
            anim.speed = 1f;
            }

        }

    }

    public void IncreaseMovementSpeed(float amount)
    {
        movementSpeed += amount;
    }
}



