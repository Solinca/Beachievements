using UnityEngine;
using TMPro;
using System;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI counter;

    public static bool stopTimer = false;

    private float seconds = 0f;
    private static float minutes = 0f;

    private void Start()
    {
        minutes = seconds = 0f;
        stopTimer = false;
    }

    private void FixedUpdate()
    {
        if (stopTimer)
        {
            return;
        }

        seconds += Time.deltaTime;
        seconds = (float)Math.Round(seconds * 100) / 100;

        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }

        counter.SetText((minutes >= 10 ? minutes.ToString() : "0" + minutes) + "." + (seconds >= 10 ? seconds.ToString() : "0" + seconds));
    }

    public static bool IsLessThan3Minutes()
    {
        return minutes < 3;
    }
}
