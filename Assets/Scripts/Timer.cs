﻿using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float defaultMinutes = 1f, 
        minutes = 1f,
        seconds = 59f,
        milliseconds;
    [SerializeField] private bool isCountingDown;

    private Text timerText;

    public bool IsCountingDown
    {
        get => isCountingDown;
        set => isCountingDown = value;
    }

    private void Start()
    {
        timerText = GetComponent<Text>();
        minutes = defaultMinutes;
    }

    private void Update()
    {
        if (!isCountingDown) return;
        milliseconds += Time.deltaTime;
            
        // If milliseconds is greater or equals to 1, ...
        if(milliseconds >= 1.0f)
        {
            milliseconds -= 1.0f;
                
            // If time is not up, ...
            if(seconds > 0 || minutes > 0)
            {
                seconds--; // Decrease seconds
                if (seconds < 0.0f)
                {
                    seconds = 59; // Repeat seconds
                    minutes--; // Decrease minutes;
                }
            }
            else // If time is up, ...
            {
                isCountingDown = false;
            }
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        timerText.text = $"{minutes:00} : {seconds:00}";
    }
}