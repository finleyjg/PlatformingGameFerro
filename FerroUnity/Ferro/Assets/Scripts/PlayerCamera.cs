using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;        
    public Vector3 offset = new Vector3(0, 5, -10); 
    public float rotationSpeed = 5f; 
    public float smoothingSpeed = 0.2f; 
    public float verticalMax = 90f; 
    private float currentRotationX = 0f;
    private float currentRotationY = 0f; 
    private Quaternion requiredRotation; 
    private Vector3 requiredPosition; 

    void Start()//this part of the code finds the player, locks the cursor to them and also makes the cursor invisible
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;  
        }

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed; 
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed; 

        currentRotationX += mouseX;
        currentRotationY -= mouseY;
        currentRotationY = Mathf.Clamp(currentRotationY, -verticalMax, verticalMax);//stops camera rotating past the max
        requiredRotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);
        requiredPosition = player.position + requiredRotation * offset;
        transform.position = Vector3.Lerp(transform.position, requiredPosition, smoothingSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, requiredRotation, smoothingSpeed);
        //linear interpolation - makes the camera move smoothly
    }
}
