using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public TMP_Text boneText;
    public TMP_Text magicText;
    public TMP_Text LvlText;
    public List<TMP_Text> lvlTextList = new List<TMP_Text>();
    public TMP_Text skillPointsText;
    public List<TMP_Text> skillPointsList = new List<TMP_Text>();

    public GameObject SidePanelGreen;
    public GameObject SidePanelBlue;
    public GameObject SidePanelRed;
    public GameObject SidePanelYellow;
    public GameObject SidePanelLightblue;
    // public List<GameObject> SidePanel = new List<GameObject>();
    // public List<GameObject> Researchtree = new List<GameObject>();
    public GameObject ResearchGreen;
    public GameObject ResearchBlue;
    public GameObject ResearchRed;
    public GameObject ResearchYellow;
    public GameObject ResearchLightblue;

    public GameObject InfoCitadel;
    public GameObject InfoMidgard;


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
        AudioManager.Instance.PlayUI("Button_click_1");

        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }
      public void ShowHideEnchant()
    {
        if(enchant.activeSelf == false)
        {
            CheckIfDiscovered(); // does nothing for now
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
            CheckIfDiscovered(); // does nothing for now
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
        if(glossary.activeSelf == false)
        {
            glossary.SetActive(true);
        } else
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

    public void changeButton()
    {
        // change colour of new button to color code

        // change other button to neutral color code
        return;
    }

    public void CheckIfDiscovered()
    {
        // momentan nur für ice forschung
        for(int i = 0; i < ForschungsController.instance.discoveredCalm.Length; i++)
        {
            if (ForschungsController.instance.discoveredCalm[i] != 0)
            {
                // change button accordingly
                changeButton(); // does nothing for now
                return;
            }
        }
    }

    public void HideAllSidePanel()
    {
        SidePanelGreen.SetActive(false);
        SidePanelBlue.SetActive(false);
        SidePanelRed.SetActive(false);
        SidePanelYellow.SetActive(false);
        SidePanelLightblue.SetActive(false);
    }

    public void HideAllResearchtree()
    {
        ResearchGreen.SetActive(false);
        ResearchBlue.SetActive(false);
        ResearchRed.SetActive(false);
        ResearchYellow.SetActive(false);
        ResearchLightblue.SetActive(false);
    }

    public void ShowGreenSidepanel()
    {
        HideAllSidePanel();
        SidePanelGreen.SetActive(true);
    }
    public void ShowBlueSidepanel()
    {
        HideAllSidePanel();
        SidePanelBlue.SetActive(true);
    }

    public void ShowRedSidepanel()
    {
        HideAllSidePanel();
        SidePanelRed.SetActive(true);
    }

    public void ShowYellowSidepanel()
    {
        HideAllSidePanel();
        SidePanelYellow.SetActive(true);
    }

    public void ShowLightblueSidepanel()
    {
        HideAllSidePanel();
        SidePanelLightblue.SetActive(true);
    }

    public void ShowGreenResearch()
    {
        HideAllResearchtree();
        ShowHideResearch();
        ResearchGreen.SetActive(true);
    }

    public void ShowBlueResearch()
    {
        HideAllResearchtree();
        ShowHideResearch();
        ResearchBlue.SetActive(true);
    }

    public void ShowRedResearch()
    {
        HideAllResearchtree();
        ShowHideResearch();
        ResearchRed.SetActive(true);
    }

    public void ShowYellowResearch()
    {
        HideAllResearchtree();
        ShowHideResearch();
        ResearchYellow.SetActive(true);
    }

    public void ShowLightblieResearch()
    {
        HideAllResearchtree();
        ShowHideResearch();
        ResearchLightblue.SetActive(true);
    }

}

