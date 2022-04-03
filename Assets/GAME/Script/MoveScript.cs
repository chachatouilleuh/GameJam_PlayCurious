using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField, Tooltip("component characontroller player")] private CharacterController m_controller;

    [SerializeField, Tooltip("speed player")] private float m_speed;

    [SerializeField, Tooltip("Height jump player")] private float m_jumpHeight;

    [SerializeField, Tooltip("le layer du ground")] private LayerMask m_groundLayer;

    [SerializeField, Tooltip("la velocity de chute")] private Vector3 m_velocity;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x +transform.up * 1f + transform.forward * z;

        m_controller.Move(move * m_speed * Time.deltaTime);
    }

    // private void OnCollisionStay(Collision p_collision)
    // {
    //     if ((m_groundLayer.value & (1 << p_collision.gameObject.layer)) > 0)
    //     {
    //         if (Input.GetButtonDown("Jump"))
    //         {
    //             m_velocity.y = m_jumpHeight;
    //         }
    //     }
    // }
}
