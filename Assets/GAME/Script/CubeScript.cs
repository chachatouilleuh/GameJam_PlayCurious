using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeScript : MonoBehaviour
{
    [SerializeField, Tooltip("Cube value")]
    private int m_PointsCount;
    
    [SerializeField, Tooltip("layer des boites")]
    private LayerMask m_ZoneLayer;
    
    private int m_pointsAccount;

    private Coroutine m_pointsGainedCor;

    [SerializeField, Tooltip("script player")]
    private Player m_player;

    private void OnEnable()
    {
        // m_pointsGainedCor = StartCoroutine(PointsGained());
        // InvokeRepeating("LaunchCoroutine", 0f, 10f);
        // LaunchCoroutine();
    }

    private void OnDisable()
    {
        if (m_pointsGainedCor != null)
        {
            StopCoroutine(m_pointsGainedCor);
            m_pointsGainedCor = null;
        }
    }

    private void Update()
    {
        if (m_player.m_isHolding == true)
        {
            if (m_pointsGainedCor != null)
            {
                StopCoroutine(m_pointsGainedCor);
                m_pointsGainedCor = null;
            }
            Debug.Log("la coroutine s'arrete");
        }
    }

    void LaunchCoroutine()
    {
        m_pointsGainedCor = StartCoroutine(PointsGained());
    }

    IEnumerator PointsGained()
    {
        m_pointsAccount += m_PointsCount;
        Debug.Log($"Tu as {m_pointsAccount} points !");
        yield return new WaitForSeconds(2);
    }

    private void OnTriggerStay(Collider other)
    {
        if ((m_ZoneLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            m_pointsGainedCor = StartCoroutine(PointsGained());
            InvokeRepeating("LaunchCoroutine", 0f, 2f);
            LaunchCoroutine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((m_ZoneLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (m_pointsGainedCor != null)
            {
                StopCoroutine(m_pointsGainedCor);
                m_pointsGainedCor = null;
            }
            Debug.Log(("la box sort de la zone"));
        }
    }
}
