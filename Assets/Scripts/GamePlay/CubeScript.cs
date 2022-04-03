using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeScript : MonoBehaviour
{
    [SerializeField, Tooltip("transform de cube")]
    private Transform m_cubeTransform0;
    
    [SerializeField, Tooltip("transform de cube")]
    private Transform m_cubeTransform1;

    private void Update()
    {
        m_cubeTransform0.transform.position = new Vector3(transform.position.x, m_cubeTransform0.transform.position.y, transform.position.z);
    }
}
