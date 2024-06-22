using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuYggUIController : MonoBehaviour
{
    public static MenuYggUIController instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject menuScreen;
    public GameObject startscreen;
    public GameObject loreScreen;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.musicPlaylist = new string[] { "MenuTheme"};
        AudioManager.Instance.StartPlaylist();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void menuScreenShowHide()
    {
        if (menuScreen.activeSelf == false)
        {
            menuScreen.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            menuScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }
    public void startscreenShowHide()
    {
        if (startscreen.activeSelf == false)
        {
            startscreen.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            startscreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }
    public void loreScreenShowHide()
    {
        if (loreScreen.activeSelf == false)
        {
            lorePopUp.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            lorePopUp.SetActive(false);

            Time.timeScale = 1f;
        }
    }
}
