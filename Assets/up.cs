using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    public Transform elevator;
    public float m_Thrust = 20f;
    void FixedUpdate()
    {
        elevator.transform.position = transform.position + new Vector3(0,m_Thrust * Time.deltaTime ,0);
    }
}