using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaZone : MonoBehaviour
{
    [SerializeField, Tooltip("layer des boites")]
    private LayerMask m_BoxLayer;

    private void OnTriggerStay(Collider other)
    {
        if ((m_BoxLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("y a un cube la dis donc");
        }
    }
}
