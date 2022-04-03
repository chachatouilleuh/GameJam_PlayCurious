using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SablierCamRotate : MonoBehaviour
{

    [SerializeField, Tooltip("point de pivot pour la camera du sablier")]
    private Transform sablierCam;

    [SerializeField, Tooltip("vitesse de rotation")]
    private float vitesse;
    
    void Update()
    {
        sablierCam.transform.Rotate(0, vitesse * Time.deltaTime, 0, Space.Self);
    }
}
