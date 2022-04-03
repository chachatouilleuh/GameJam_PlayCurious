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
    
    //code porter un objet et le lacher
    [SerializeField, Tooltip("le layer de l'objet")]
    private LayerMask m_pickable_Object;

    [SerializeField, Tooltip("la range pour pick l'objet")]
    private float m_distance;
    
    [SerializeField, Tooltip("recup le transform de la 'main'")]
    private Transform m_hand;

    [SerializeField, Tooltip("puissance du jet")]
    private float m_punch;

    private Rigidbody m_rigidbody;
    private Collider m_collider;

    [SerializeField, Tooltip("gameobject target")]
    private GameObject m_curTarget;


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

        bool isRunning = Input.GetButton("Run");
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
        
        //code porter un objet et le lacher
        Ray pickupRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward * m_distance);

        RaycastHit hit;

        if (Input.GetButton("PickUp"))
        {
            if (Physics.Raycast(pickupRay, out hit, m_distance, m_pickable_Object))
            {
                if (!m_rigidbody)
                {
                    m_rigidbody = hit.rigidbody;
                    m_collider = hit.collider;

                    m_rigidbody.isKinematic = true;
                    m_rigidbody.useGravity = false;
                    m_collider.enabled = false;

                    m_curTarget.GetComponent<CubeScript>().enabled = true;
                }

                return;
            }
            
            if(m_rigidbody)
            {
                m_rigidbody.isKinematic = false;
                m_rigidbody.useGravity = true;
                m_collider.enabled = true;

                m_rigidbody = null;
                m_collider = null;
                
                m_curTarget.GetComponent<CubeScript>().enabled = false;
            }
        }

        if (Input.GetButton("Throw"))
        {
            if (!m_rigidbody)
            {
            }
            else
            {
                m_rigidbody.isKinematic = false;
                m_rigidbody.useGravity = true;
                m_collider.enabled = true;
            
                m_rigidbody.AddForce(m_hand.transform.forward * m_punch);

                m_rigidbody = null;
                m_collider = null;
                
                m_curTarget.GetComponent<CubeScript>().enabled = false;
            }
        }

        if (m_rigidbody)
        {
            m_rigidbody.position = m_hand.position;
            m_rigidbody.rotation = m_hand.rotation;
        }
    }

   
}