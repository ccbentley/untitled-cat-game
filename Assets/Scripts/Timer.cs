using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeValue = 0;
    public TMP_Text timeText;

    private bool timerActive = true;

    private void Update()
    {
        if(timerActive)
        {
            timeValue += Time.deltaTime;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void StopTimer()
    {
        timerActive = false;
    }
    public  void StartTimer()
    {
        timerActive = true;
    }

    public void UpdateLastTime()
    {
        Variables.lastTime = timeValue;
        if (timeValue < Variables.bestTime || Variables.bestTime < 0)
        {
            Variables.bestTime = timeValue;
        }
    }
}
