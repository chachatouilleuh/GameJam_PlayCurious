using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField, Tooltip("time remaining")]private float m_timeRemaining;

    [SerializeField, Tooltip("time at start")] private float m_timeAtStart;
    
    [SerializeField, Tooltip("time")] private Text m_countdownText;
    
    // public bool timerIsRunning = false;
    // public Text timeText;

    private void Awake()
    {
        m_timeRemaining = m_timeAtStart;
    }

    void Update()
    {
        m_timeRemaining -= 1 * Time.deltaTime;
        m_countdownText.text = m_timeRemaining.ToString("0");

        if (m_timeRemaining < 51)
        {
            m_countdownText.color = Color.red;
        }
        
        if (m_timeRemaining < 0)
        {
            m_timeRemaining = 0;
        }
        // if (timerIsRunning)
        // {
        //     if (timeRemaining > 0)
        //     {
        //         timeRemaining -= UnityEngine.Time.deltaTime;
        //         DisplayTime(timeRemaining);
        //     }
        //     if(timeRemaining < 0)
        //     {
        //         timeRemaining = 0;
        //         timerIsRunning = false;
        //     }
        // }
        // GetComponent<UnityEngine.UI.Text>().text = timeText.ToString();
    }
    //
    // void DisplayTime(float timeToDisplay)
    // {
    //     timeToDisplay += 1;
    //
    //     float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    //     float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    //
    //     timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    // }
}