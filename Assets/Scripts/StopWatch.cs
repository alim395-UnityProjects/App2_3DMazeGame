using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Diagnostics;

public class StopWatch : MonoBehaviour
{
    bool stopWatchActive = false;
    float currentTime = 0;
    public TMP_Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive)
        {
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        String timeString = String.Format("{0:D2}:{1:D2}:{2:D3}", time.Minutes.ToString(), time.Seconds.ToString(), time.Milliseconds.ToString());
        currentTimeText.SetText(timeString);
    }

    public void startStopWatch()
    {
        stopWatchActive = true;
    }

    public void stopStopWatch()
    {
        stopWatchActive = false;
    }

    public string getCurrentTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        String timeString = String.Format("{0:D2}:{1:D2}:{2:D3}", time.Minutes.ToString(), time.Seconds.ToString(), time.Milliseconds.ToString());
        return timeString;
    }
}
