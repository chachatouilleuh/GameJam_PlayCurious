using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("walkingSpeed")]
    private float walkingSpeed = 7.5f;

    [SerializeField, Tooltip("runningSpeed")]
    private float runningSpeed = 11.5f;

    [SerializeField, Tooltip("jumpSpeed")]
    private float jumpSpeed = 8.0f;

    [SerializeField, Tooltip("gravity")]
    private float gravity = 20.0f;

    [SerializeField, Tooltip("playerCamera")]
    private Camera playerCamera;

    [SerializeField, Tooltip("lookSpeed")]
    private float lookSpeed = 2.0f;

    [SerializeField, Tooltip("lookXLimit")]
    private float lookXLimit = 45.0f;

    [SerializeField, Tooltip("characterController")]
    CharacterController characterController;

    [SerializeField, Tooltip("moveDirection")]
    Vector3 moveDirection = Vector3.zero;

    [SerializeField, Tooltip("rotationX")]
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }


        if (Input.GetMouseButtonDown(0))
        {
            



        }

        
    }

   
}