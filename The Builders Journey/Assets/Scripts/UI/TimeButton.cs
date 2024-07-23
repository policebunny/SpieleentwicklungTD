using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    public static TimeButton instance;
    private float timestamp;

    public Sprite pausedIcon;
    public Sprite playingIcon;

    public Image pauseButtonImage; // Reference to the pause button image
    public Text timeScaleText; // Reference to the UI Text element to display the time scale

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timestamp = Time.timeScale;
        UpdateTimeScaleText();
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
        UpdateTimeScaleText();
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
        UpdateTimeScaleText();
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
        UpdateTimeScaleText();
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

    private void UpdateTimeScaleText()
    {
        if(Time.timeScale == 0){
            timeScaleText.text = "Pause";

        }
        else{
            timeScaleText.text = Time.timeScale.ToString("0.00") + "x";
        }
    }
}
