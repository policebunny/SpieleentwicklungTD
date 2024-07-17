using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ControllerHelper : MonoBehaviour
{
    public static UI_ControllerHelper instance;

    public GameObject glossary, options;
    public GameObject OpSound, OpDisplay;

    public List<GameObject> SidepanelGlossary = new List<GameObject>();
    public List<GameObject> SidepanelLightblue = new List<GameObject>();

    private void Awake()
    {
        instance = this;
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

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HideAllPanel()
    {
        foreach (GameObject panel in SidepanelGlossary)
        {
            panel.SetActive(false);
        }
        foreach (GameObject panel in SidepanelLightblue)
        {
            panel.SetActive(false);
        }
    }

    public void ShowSidepanelLore()
    {
        HideAllPanel();
        SidepanelGlossary[0].SetActive(true);
    }

    public void ShowSidepanelCitadel()
    {
        HideAllPanel();
        SidepanelGlossary[1].SetActive(true);
    }

    public void ShowSidepanelAsgard()
    {
        HideAllPanel();
        SidepanelGlossary[2].SetActive(true);
    }

    public void ShowSidepanelAlfheim()
    {
        HideAllPanel();
        SidepanelGlossary[3].SetActive(true);
    }

    public void ShowSidepanelMuspelheim()
    {
        HideAllPanel();
        SidepanelGlossary[4].SetActive(true);
    }

    public void ShowSidepanelMidgard()
    {
        HideAllPanel();
        SidepanelGlossary[5].SetActive(true);
    }
    public void ShowSidepanelVanaheim()
    {
        HideAllPanel();
        SidepanelGlossary[6].SetActive(true);
    }

    public void ShowSidepanelNidavellir()
    {
        HideAllPanel();
        SidepanelGlossary[7].SetActive(true);
    }

    public void ShowSidepanelJotunheim()
    {
        HideAllPanel();
        SidepanelGlossary[8].SetActive(true);
    }

    public void ShowSidepanelNilfheim()
    {
        HideAllPanel();
        SidepanelGlossary[9].SetActive(true);
    }

    public void ShowSidepanelHelmheim()
    {
        HideAllPanel();
        SidepanelGlossary[10].SetActive(true);
    }

    public void ShowSidepanelCalmness0()
    {
        HideAllPanel();
        SidepanelLightblue[0].SetActive(true);
    }

    public void ShowSidepanelCalmness1()
    {
        HideAllPanel();
        SidepanelLightblue[1].SetActive(true);
    }

    public void ShowSidepanelCalmness2()
    {
        HideAllPanel();
        SidepanelLightblue[2].SetActive(true);
    }

    public void ShowSidepanelCalmness3()
    {
        HideAllPanel();
        SidepanelLightblue[3].SetActive(true);
    }

    public void ShowSidepanelCalmness4()
    {
        HideAllPanel();
        SidepanelLightblue[4].SetActive(true);
    }

    public void ShowSidepanelCalmness5()
    {
        HideAllPanel();
        SidepanelLightblue[5].SetActive(true);
    }

    public void ShowSidepanelCalmness6()
    {
        HideAllPanel();
        SidepanelLightblue[6].SetActive(true);
    }

}
