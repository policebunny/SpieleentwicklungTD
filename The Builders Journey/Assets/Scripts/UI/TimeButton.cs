using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    public static TimeButton instance;
    private float timestamp;

    public Sprite pausedIcon;
    public Sprite playingIcon;

    public Image pauseButtonImage; // Referenz zum Pause-Button-Image

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

    public void PauseButton()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        UpdateButtonIcon();
    }

    public void TimeFaster()
    {
        timestamp += 0.25f;
        if (timestamp >= 3f)
        {
            timestamp = 3f;
        }
        Time.timeScale = timestamp;

        UpdateButtonIcon();
    }

    public void TimeSlower()
    {
        timestamp -= 0.25f;
        if (timestamp <= 0f)
        {
            timestamp = 0.25f;
        }
        Time.timeScale = timestamp;

        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (Time.timeScale == 0)
        {
            pauseButtonImage.sprite = pausedIcon;
        }
        else
        {
            pauseButtonImage.sprite = playingIcon;
        }
    }
}
