using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClaZone : MonoBehaviour
{
    [SerializeField, Tooltip("total points")]
    private ScoreScript m_scoreScript;
    
    [SerializeField, Tooltip("layer des boites")]
    private LayerMask m_Layer;

    private Coroutine m_pointsGainedCor;

    private void OnTriggerStay(Collider other)
    {
        if ((m_Layer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (other.gameObject.CompareTag("cube1"))
            {
                m_scoreScript.m_scorePlayer += 1;
            }
            else if (other.gameObject.CompareTag("cube5"))
            {
                m_scoreScript.m_scorePlayer += 5;
            }
        }
    }
}
