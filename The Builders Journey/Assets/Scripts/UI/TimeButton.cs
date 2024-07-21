using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    public static TimeButton instance;
    private float timestamp;

    public Sprite pausedIcon;
    public Sprite playingIcon;

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

    public void PauseButton(Image buttonImage)
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        UpdateButtonIcon(buttonImage);
    }

    public void TimeFaster()
    {
        timestamp += 0.25f;
        if (timestamp >= 3f)
        {
            timestamp = 3f;
        }
        Time.timeScale = timestamp;
    }

    public void TimeSlower()
    {
        timestamp -= 0.25f;
        if (timestamp <= 0f)
        {
            timestamp = 0.25f;
        }
        Time.timeScale = timestamp;
    }

    private void UpdateButtonIcon(Image buttonImage)
    {
        if (Time.timeScale == 0)
        {
            buttonImage.sprite = pausedIcon;
        }
        else
        {
            buttonImage.sprite = playingIcon;
        }
    }
}
