using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreScript : MonoBehaviour
{
    public int m_scorePlayer;

    private void Start()
    {
        m_scorePlayer = 0;
    }

    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = $" Score : {m_scorePlayer.ToString()}";
    }
}
