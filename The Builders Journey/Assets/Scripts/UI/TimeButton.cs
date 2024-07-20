using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButton : MonoBehaviour
{
    public static TimeButton instance;
    private float timestamp;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timestamp = Time.timeScale;
    }

    public float getTimeStamp()
    {
        return timestamp;
    }

    // Update is called once per frame
    public void PauseButton()
    {
        if(Time.timeScale > 0)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = timestamp;
        }
    }

    public void TimeFaster()
    {
        timestamp += 0.25f;
        if(timestamp >= 3f)
        {
            timestamp = 3f;
        }
        Time.timeScale = timestamp;
    }

    public void TimeSlower()
    {
        timestamp -= 0.25f;
        if(timestamp <= 0f)
        {
            timestamp = 0.25f;
        }
        Time.timeScale = timestamp;
    }
}
