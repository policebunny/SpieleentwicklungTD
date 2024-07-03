using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControllerNew : MonoBehaviour
{
     public static UIControllerNew instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject pauseScreen;
    public GameObject citadel;
    public GameObject research;
    public GameObject enchant;
    public GameObject glossary;
    public GameObject options;

    public GameObject InfoCitadel;
    public GameObject InfoMidgard;
    public GameObject OpSound;
    public GameObject OpDisplay;

    public TMP_Text boneText;
    public TMP_Text magicText;
    public TMP_Text LvlText;
    public List<TMP_Text> lvlTextList = new List<TMP_Text>();
    public TMP_Text skillPointsText;
    public List<TMP_Text> skillPointsList = new List<TMP_Text>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
     public void PauseUnpause()
    {        
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
        AudioManager.Instance.PlayUI("Button_click_1");
    }
      public void ShowHideEnchant()
    {
        if(enchant.activeSelf == false)
        {
            enchant.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            enchant.SetActive(false);

            Time.timeScale = 1f;
        }

    }

     public void ShowHideResearch()
    {
        if(research.activeSelf == false)
        {
            research.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            research.SetActive(false);

            Time.timeScale = 1f;
        }
    }
      public void ShowHideCitadel()
    {
        if(citadel.activeSelf == false)
        {
            citadel.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            citadel.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void ShowHideGlossary()
    {
        if (glossary.activeSelf == false)
        {
            glossary.SetActive(true);
        }
        else
        {
            glossary.SetActive(false);
        }
    }

    public void GlossaryCitadel()
    {
        InfoMidgard.SetActive(false);
        InfoCitadel.SetActive(true);
    }

    public void GlossaryMidgard()
    {
        InfoCitadel.SetActive(false);
        InfoMidgard.SetActive(true);
    }

    public void ShowHideOptions()
    {
        if (options.activeSelf == false)
        {
            options.SetActive(true);
        }
        else
        {
            options.SetActive(false);
        }
    }

    public void OptionsSound()
    {
        OpDisplay.SetActive(false);
        OpSound.SetActive(true);
    }

    public void OptionsDisplay()
    {
        OpSound.SetActive(false);
        OpDisplay.SetActive(true);
    }
}

