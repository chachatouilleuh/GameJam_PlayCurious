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
        m_cubeTransform0.transform.position = new Vector3(m_cubeTransform1.position.x, transform.position.y, m_cubeTransform1.position.z);
    }
}
