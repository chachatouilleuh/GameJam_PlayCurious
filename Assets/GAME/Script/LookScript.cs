using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    [SerializeField, Tooltip("vitesse mouve mouse")]
    private float m_mouseSensitivy;

    [SerializeField, Tooltip("recup le transform du player")]
    private Transform m_playerBody;

    [SerializeField, Tooltip("rotation camera")]
    private float m_xRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivy * Time.deltaTime;

        m_xRotation -= mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        m_playerBody.Rotate(Vector3.up * mouseX);
    }
}
