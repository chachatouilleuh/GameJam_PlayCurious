using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audiosource;
    [SerializeField, Tooltip("le son est deja joue")]
    private bool alreadyPlayed;
    
    [SerializeField, Tooltip("layer des boites")]
    private LayerMask m_Layer;
    
    private void Start()
    {
        audiosource.Stop();
        alreadyPlayed = false;
    }
    
    private void OnTriggerEnter(Collider Cube)
    {
        if ((m_Layer.value & (1 << Cube.gameObject.layer)) > 0 && !alreadyPlayed)
        {
            audiosource.Play();
            alreadyPlayed = true;
        }
    }
}
